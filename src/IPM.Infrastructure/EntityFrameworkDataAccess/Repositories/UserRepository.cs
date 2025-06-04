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

        if (queryParam.Include is not null)
        {
            query = IncludeWith(query, queryParam.GetIncludeList);
        }

        User? user = await query.FirstOrDefaultAsync();

        if (user is null)
        {
            return null;
        }
        return user.MapTo();
    }


    protected virtual IQueryable<User> IncludeWith(IQueryable<User> query, string[] includeList)
    {
        foreach (var item in includeList)
        {
            if (item.Equals("Role"))
            {
                query = query.Include(e => e.UserRoles)!.ThenInclude(e => e.Role);
            } else if(item.Equals("Participations"))
                query = query.Include(e => e.Participations)!.ThenInclude(e => e.Project);
            else {
                query = query.Include(item);
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

    private Dictionary<string, string[]> GetCreateErrors(IdentityResult result)
    {
        var errorDictionary = new Dictionary<string, string[]>(1);

        foreach (var error in result.Errors)
        {
            string[] newDescriptions;

            if (errorDictionary.TryGetValue(error.Code, out var descriptions))
            {
                newDescriptions = new string[descriptions.Length + 1];
                Array.Copy(descriptions, newDescriptions, descriptions.Length);
                newDescriptions[descriptions.Length] = error.Description;
            }
            else
            {
                newDescriptions = [error.Description];
            }

            errorDictionary[error.Code] = newDescriptions;
        }

        return errorDictionary;
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

        if (queryParam.Include is not null)
        {
            query = IncludeWith(query, queryParam.GetIncludeList);
        }

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
            if(property.Name == "CreatedAt" || property.Name == "UserId" ) {
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
}
