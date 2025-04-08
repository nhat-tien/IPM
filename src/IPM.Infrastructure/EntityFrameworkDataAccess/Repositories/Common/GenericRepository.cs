using System.Linq.Expressions;
using System.Reflection;
using IPM.Application.Queries;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

public abstract class GenericRepository<TDomain, TEntity>
    where TDomain : class
    where TEntity : BaseEntity
{
    protected AppDBContext db { get; set; }

    protected GenericRepository(AppDBContext ctx)
    {
        db = ctx;
    }

    public abstract TEntity MapFromDomain(TDomain domain);

    public abstract TDomain MapToDomain(TEntity entity);

    public abstract int GetDomainId(TDomain domain);

    public abstract IQueryable<TEntity> WhereId(int id);

    public virtual async Task AddAsync(TDomain domain)
    {
        TEntity entity = MapFromDomain(domain);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await db.Set<TEntity>().AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        try {
            await WhereId(id).ExecuteDeleteAsync();
        }
        catch(PostgresException e)
        {
            DbExceptionHandler.TryHandle(e);
        }
    }

    public virtual async Task<IEnumerable<TDomain>> GetAllAsync()
    {
        List<TEntity> entity = await db.Set<TEntity>().ToListAsync();
        IEnumerable<TDomain> listOfDomain = entity.Select(entity => MapToDomain(entity));
        return listOfDomain;
    }

    protected virtual IQueryable<TEntity> IncludeWith(IQueryable<TEntity> query, string[] includeList)
    {
        foreach (var item in includeList)
        {
            query = query.Include(item);
        }
        return query;
    }

    protected virtual IQueryable<TEntity> Sort(
        IQueryable<TEntity> query,
        Expression<Func<TEntity, object>> keySelector,
        bool isDesc = false
    )
    {
        if(isDesc)
        {
            query = query.OrderByDescending(keySelector);
        } else 
        {
            query = query.OrderBy(keySelector);
        }
        return query;
    }

    public virtual async Task<IEnumerable<TDomain>> GetAllAsync(CriteriaQuery queryParam)
    {
        IQueryable<TEntity> query = db.Set<TEntity>();

        if(queryParam.Include is not null)
        {
            query = IncludeWith(query, queryParam.GetIncludeList);
        }

        List<TEntity> entity = await query.ToListAsync();

        IEnumerable<TDomain> listOfDomain = entity.Select(entity => MapToDomain(entity));

        return listOfDomain;
    }

    public virtual async Task<TDomain?> FindByIdAsync(int id)
    {
        TEntity? entity = await db.Set<TEntity>().FindAsync(id);

        if (entity is null)
        {
            return null;
        }
        return MapToDomain(entity);
    }

    public virtual async Task<TDomain?> FindByIdAsync(int id, CriteriaQuery queryParam)
    {
        IQueryable<TEntity> query = WhereId(id);

        if(queryParam.Include is not null)
        {
            query = IncludeWith(query, queryParam.GetIncludeList);
        }

        TEntity? entity = await query.FirstOrDefaultAsync();

        if (entity is null)
        {
            return null;
        }

        return MapToDomain(entity);
    }

    public virtual async Task<IEnumerable<TDomain>> GetBy(IQueryable<TEntity> query, CriteriaQuery queryParam)
    {

        if(queryParam.Include is not null)
        {
            query = IncludeWith(query, queryParam.GetIncludeList);
        }

        List<TEntity> entity = await query.ToListAsync();

        IEnumerable<TDomain> listOfDomain = entity.Select(entity => MapToDomain(entity));

        return listOfDomain;
    }


    public virtual async Task UpdateAsync(TDomain domain)
    {
        var domainId = GetDomainId(domain);
        TEntity? entity = await WhereId(domainId).FirstOrDefaultAsync();
        if (entity is null)
            return;
        db.Set<TEntity>().Attach(entity);

        Type typeOfModel = domain.GetType();
        PropertyInfo[] properties = typeOfModel.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if(property.Name == "CreatedAt") {
                continue;
            }
            if (property.GetValue(domain) is not null)
            {
                db.Entry(entity).Property(property.Name).CurrentValue = property.GetValue(domain);
            }
        }
        entity.UpdatedAt = DateTime.UtcNow;
        await db.SaveChangesAsync();
    }
}
