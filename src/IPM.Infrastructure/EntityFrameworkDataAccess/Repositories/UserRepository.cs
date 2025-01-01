using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class UserRepository(UserManager<User> userManager) : IUserRepository
{
    public async Task<bool> CheckPassword(Domain.User domainUser, string password)
    {
        User? user = await userManager.FindByIdAsync(domainUser.UserId ?? "");
        if(user is null) {
            return false;
        }
        return await userManager.CheckPasswordAsync(user, password);
    }

    public async Task<Domain.User?> FindByName(string name)
    {
        User? user = await userManager.FindByNameAsync(name);
        if( user is null) 
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
        if(user is null) {
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
        if(user is not null) {
            Console.WriteLine("Hello");
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

}