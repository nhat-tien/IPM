using System.Linq.Expressions;
using System.Reflection;
using IPM.Application.IRepositories;
using IPM.Application.Queries;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class UserRepository(UserManager<User> userManager, AppDBContext db) : IUserRepository
{
    public async Task<bool> CheckPassword(Domain.User domainUser, string password)
    {
        User? user = await userManager.FindByIdAsync(domainUser.UserId ?? "");
        if (user is null)
        {
            return false;
        }
        return await userManager.CheckPasswordAsync(user, password);
    }

    public async Task<Domain.User?> FindByName(string name)
    {
        User? user = await userManager.FindByNameAsync(name);
        if (user is null)
        {
            return null;
        }
        return user.MapTo();
    }

    public async Task<Domain.User?> GetById(string id)
    {
        User? user = await userManager.FindByIdAsync(id);
        if (user is null)
        {
            return null;
        }
        return user.MapTo();
    }

    public async Task<Domain.User?> GetById(string id, CriteriaQuery queryParam)
    {
        IQueryable<User> query = userManager.Users.Where(e => e.Id == id);

        query = IncludeWith(query, queryParam);

        User? user = await query.FirstOrDefaultAsync();

        if (user is null)
        {
            return null;
        }
        return user.MapTo();
    }


    protected virtual IQueryable<User> IncludeWith(IQueryable<User> query, CriteriaQuery queryParam)
    {

        if (queryParam.Include is not null)
        {
            var includeList = queryParam.GetIncludeList;

            foreach (var item in includeList)
            {
                if (item.Equals("Role"))
                {
                    query = query.Include(e => e.UserRoles)!.ThenInclude(e => e.Role);
                }
                else if (item.Equals("Participations"))
                    query = query
                        .Include(e => e.Participations!.Where(part => part.Project!.IsDeleted == false))
                        !.ThenInclude(e => e.Project);
                else
                {
                    query = query.Include(item);
                }
            }
        }
        return query;
    }

    public async Task<IList<string>> GetRoles(Domain.User domainUser)
    {
        User? user = await userManager.FindByIdAsync(domainUser.UserId ?? "");
        if (user is null)
        {
            return [];
        }
        return await userManager.GetRolesAsync(user);
    }

    public async Task<CreateResult> CreateAsync(Domain.User domainUser, string password)
    {
        var user = User.MapFrom(domainUser);
        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            return CreateResult.Ok("Dang ki thanh cong");
        }
        else
        {
            return CreateResult.Error(GetCreateErrors(result));
        }
    }

    public async Task AddToRole(Domain.User domainUser, string roleName)
    {
        User? user = await userManager.FindByNameAsync(domainUser.UserName ?? "");
        if (user is not null)
        {
            await userManager.AddToRoleAsync(user, roleName);
        }
    }

    private string GetCreateErrors(IdentityResult result)
    {
        var errorDictionary = new Dictionary<string, string[]>(1);
        var error = result.Errors.First();
        return error.Code;
    }

    public async Task<IEnumerable<Domain.User>> GetAll()
    {
        List<User> entity = await userManager.Users.ToListAsync();
        IEnumerable<Domain.User> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task<IEnumerable<Domain.User>> GetAll(CriteriaQuery queryParam)
    {
        IQueryable<User> query = userManager.Users;

        query = IncludeWith(query, queryParam);

        query = Filter(query, queryParam);

        List<User> entity = await query.ToListAsync();

        IEnumerable<Domain.User> listOfDomain = entity.Select(entity => entity.MapTo());

        return listOfDomain;
    }

    public async Task AddAvaterUrl(string userId, string url)
    {
        await userManager.Users.Where(e => e.Id == userId)
            .ExecuteUpdateAsync(setter =>
                    setter.SetProperty(e => e.AvatarUrl, url));

    }

    public async Task UpdateAsync(Domain.User model)
    {
        User? entity = await userManager.Users.Where(e => e.Id == model.UserId).FirstOrDefaultAsync();

        if (entity is null)
            return;

        db.Users.Attach(entity);

        Type typeOfModel = model.GetType();
        PropertyInfo[] properties = typeOfModel.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if (property.Name == "CreatedAt" || property.Name == "UserId")
            {
                continue;
            }
            if (property.GetValue(model) is not null)
            {
                db.Entry(entity).Property(property.Name).CurrentValue = property.GetValue(model);
            }
        }
        entity.UpdatedAt = DateTime.UtcNow;
        await db.SaveChangesAsync();
    }

    protected IQueryable<User> Filter(IQueryable<User> query, CriteriaQuery queryParam)
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

            var param = Expression.Parameter(typeof(User), "e");
            var propExpression = Expression.Property(param, property);

            if (propExpression.Type != typeof(string))
                value = Convert.ChangeType(value, propExpression.Type);

            Expression<System.Func<User, bool>> filterLambda;
            switch (op)
            {
                case "<":
                    filterLambda = Expression.Lambda<Func<User, bool>>(
                       Expression.LessThan(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                case ">":
                    filterLambda = Expression.Lambda<Func<User, bool>>(
                       Expression.GreaterThan(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                case "=":
                    filterLambda = Expression.Lambda<Func<User, bool>>(
                       Expression.Equal(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                case ">=":
                    filterLambda = Expression.Lambda<Func<User, bool>>(
                       Expression.GreaterThanOrEqual(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                case "<=":
                    filterLambda = Expression.Lambda<Func<User, bool>>(
                       Expression.LessThanOrEqual(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                case "!=":
                    filterLambda = Expression.Lambda<Func<User, bool>>(
                       Expression.NotEqual(
                           propExpression,
                           Expression.Constant(value)
                       ),
                       param
                   );
                    break;
                default:
                    filterLambda = Expression.Lambda<Func<User, bool>>(
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
}
