using System.Reflection;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

public abstract class GenericRepository<TDomain, TEntity>
    where TDomain : class 
    where TEntity : BaseEntity 
{
    protected AppDBContext context {get; set;}
    protected GenericRepository(AppDBContext ctx)
    {
        context = ctx;
    }

    public abstract TEntity MapFromDomain(TDomain domain);
    public abstract TDomain MapToDomain(TEntity entity); 
    public abstract int GetDomainId(TDomain domain); 

    public abstract IQueryable<TEntity> WhereId(int id);

    public async Task AddAsync(TDomain domain)
    {
        TEntity entity = MapFromDomain(domain);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        await WhereId(id).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<TDomain>> GetAllAsync()
    {
        List<TEntity> entity = await context.Set<TEntity>().ToListAsync();
        IEnumerable<TDomain> listOfDomain = entity.Select(entity => MapToDomain(entity));
        return listOfDomain;
    }

    public async Task<TDomain?> FindByIdAsync(int id)
    {
        TEntity? entity = await context.Set<TEntity>().FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return MapToDomain(entity);
    }

    public async Task UpdateAsync(TDomain domain)
    {
        var domainId = GetDomainId(domain);
        TEntity? entity = await WhereId(domainId).FirstOrDefaultAsync();
        if(entity is null) return;
        context.Set<TEntity>().Attach(entity);

        Type typeOfModel = domain.GetType();
        PropertyInfo[] properties = typeOfModel.GetProperties();
        foreach(PropertyInfo property in properties) 
        {
            if(property.GetValue(domain) is not null) 
            {
                context.Entry(entity).Property(property.Name).CurrentValue = property.GetValue(domain); 
            }
        }
        entity.UpdatedAt = DateTime.UtcNow;
        await context.SaveChangesAsync();
    }
}
