using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class UserRepository(UserManager<User> userManager) : IUserRepository
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

    public async Task<IList<string>> GetRoles(Domain.User domainUser)
    {
        User? user = await userManager.FindByIdAsync(domainUser.UserId ?? "");
        if (user is null)
        {
            return [];
        }
        return await userManager.GetRolesAsync(user);
    }

    public async Task<CreateResult> Create(Domain.User domainUser, string password)
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

    public async Task<IEnumerable<Domain.User>> GetAllWithRole()
    {
        List<User> entity = await userManager
            .Users.Include(e => e.UserRoles)!
            .ThenInclude(e => e.Role)
            .ToListAsync();

        IEnumerable<Domain.User> listOfDomain = entity.Select(entity =>
        {
            ICollection<UserRole>? userRoles = entity.UserRoles;
            if (userRoles is null)
            {
                return entity.MapTo();
            }
            var userRole = userRoles.FirstOrDefault();
            var role = userRole!.Role;
            Domain.Role roleDomain = new Domain.Role() { RoleId = role!.Id, RoleName = role!.Name };
            var domain = entity.MapTo();
            domain.Role = roleDomain;
            return domain;
        });

        return listOfDomain;
    }
}
