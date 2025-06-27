using System.Linq.Expressions;
using System.Reflection;
using IPM.Application.Queries;
using IPM.Application.ResponseDto;
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

    public virtual async Task DeleteByIdAsync(int id)
    {
        try
        {
            await WhereId(id).ExecuteDeleteAsync();
        }
        catch (PostgresException e)
        {
            DbExceptionHandler.TryHandle(e, this.GetType().ToString());
        }
    }

    public virtual async Task<IEnumerable<TDomain>> GetAllAsync()
    {
        List<TEntity> entity = await db.Set<TEntity>().ToListAsync();
        IEnumerable<TDomain> listOfDomain = entity.Select(entity => MapToDomain(entity));
        return listOfDomain;
    }

    protected virtual IQueryable<TEntity> IncludeWith(IQueryable<TEntity> query, CriteriaQuery queryParam)
    {

        if (queryParam.Include is not null)
        {
            var includeList = queryParam.GetIncludeList;

            foreach (var item in includeList)
            {
                query = query.Include(item);
            }
        }
        return query;
    }

    protected virtual IQueryable<TEntity> Filter(IQueryable<TEntity> query, CriteriaQuery queryParam)
    {

        if (queryParam.Filter is null)
        {
            return query;
        }

        List<FilterItem> filterItem = queryParam.GetFilterList();

        foreach (var item in filterItem)
        {
            string property = item.Property;
            string op = item.Operator;
            object value = item.Value;

            var param = Expression.Parameter(typeof(TEntity), "e");
            var propExpression = Expression.Property(param, property);

            if (propExpression.Type != typeof(string))
                value = Convert.ChangeType(value, propExpression.Type);

            Expression<System.Func<TEntity, bool>> filterLambda;
            switch (op)
            {
                case "<":
                    filterLambda = Expression.Lambda<Func<TEntity, bool>>(
                       Expression.LessThan(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                case ">":
                    filterLambda = Expression.Lambda<Func<TEntity, bool>>(
                       Expression.GreaterThan(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                case "=":
                    filterLambda = Expression.Lambda<Func<TEntity, bool>>(
                       Expression.Equal(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                case ">=":
                    filterLambda = Expression.Lambda<Func<TEntity, bool>>(
                       Expression.GreaterThanOrEqual(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                case "<=":
                    filterLambda = Expression.Lambda<Func<TEntity, bool>>(
                       Expression.LessThanOrEqual(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                case "!=":
                    filterLambda = Expression.Lambda<Func<TEntity, bool>>(
                       Expression.NotEqual(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                default:
                    filterLambda = Expression.Lambda<Func<TEntity, bool>>(
                   Expression.Equal(
                       propExpression,
                       Expression.Constant(value)
                   ),
                   param
                   );
                    break;
            }
            query = query.Where(filterLambda);
        }
        return query;
    }

    protected virtual async Task<(IQueryable<TEntity>, PaginationResponse<TDomain>)> Pagination(
        IQueryable<TEntity> query,
        CriteriaQuery queryParam
    )
    {

        PaginationResponse<TDomain> paginationRes = new PaginationResponse<TDomain>();

        if (queryParam.Page is int page && queryParam.PageSize is int size)
        {
            query = query.Skip(page * size).Take(size);

            int totalCount = await query.CountAsync();
            int pageCount = (int)Math.Round((double)(totalCount / size));

            paginationRes = new PaginationResponse<TDomain>()
            {
                Metadata = new PaginationResponseMetadata()
                {
                    TotalCount = totalCount,
                    PageCount = pageCount,
                    Page = page,
                    PageSize = size
                },
                Data = []
            };
        }
        ;

        return (query, paginationRes);
    }



    public virtual async Task<IEnumerable<TDomain>> GetAllAsync(CriteriaQuery queryParam)
    {
        IQueryable<TEntity> query = db.Set<TEntity>();

        query = IncludeWith(query, queryParam);

        query = Filter(query, queryParam);

        query = HandleSort(query, queryParam);

        List<TEntity> entity = await query.ToListAsync();

        IEnumerable<TDomain> listOfDomain = entity.Select(entity => MapToDomain(entity));

        return listOfDomain;
    }

    public virtual async Task<PaginationResponse<TDomain>> GetAllWithPaginationAsync(CriteriaQuery queryParam)
    {
        IQueryable<TEntity> query = db.Set<TEntity>();

        PaginationResponse<TDomain> paginationRes = new PaginationResponse<TDomain>();

        query = IncludeWith(query, queryParam);

        query = Filter(query, queryParam);

        query = HandleSort(query, queryParam);

        var (newQuery, pagination) = await Pagination(query, queryParam);
        query = newQuery;
        paginationRes = pagination;

        List<TEntity> entity = await query.ToListAsync();

        IEnumerable<TDomain> listOfDomain = entity.Select(entity => MapToDomain(entity));

        paginationRes.Data = listOfDomain;

        return paginationRes;
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

        query = IncludeWith(query, queryParam);

        TEntity? entity = await query.FirstOrDefaultAsync();

        if (entity is null)
        {
            return null;
        }

        return MapToDomain(entity);
    }

    public virtual async Task<IEnumerable<TDomain>> GetBy(IQueryable<TEntity> query, CriteriaQuery queryParam)
    {

        query = IncludeWith(query, queryParam);

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
            if (property.Name == "CreatedAt")
            {
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


    public virtual IQueryable<TEntity> HandleSort(IQueryable<TEntity> query, CriteriaQuery queryParam)
    {
        if (queryParam.SortColumn is not null && queryParam.SortOrder is not null)
        {
            switch (queryParam.SortColumn)
            {
                case "CreatedAt":
                    query = Sort(query, (e) => e.CreatedAt, queryParam.SortOrder == "desc");
                    break;
            }
        }

        return query;
    }

    protected virtual IQueryable<TEntity> Sort(
        IQueryable<TEntity> query,
        Expression<Func<TEntity, object>> keySelector,
        bool isDesc = false
    )
    {
        if (isDesc)
        {
            query = query.OrderByDescending(keySelector);
        }
        else
        {
            query = query.OrderBy(keySelector);
        }
        return query;
    }

}
