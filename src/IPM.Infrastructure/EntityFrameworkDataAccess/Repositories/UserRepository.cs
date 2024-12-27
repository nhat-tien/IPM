using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class UserRepository(UserManager<User> userManager) : IUserRepository
{
    public async Task<Domain.User?> GetById(string id)
    {
        User? user = await userManager.FindByIdAsync(id);
        if (user is null)
        {
            return null;
        }
        return new Domain.User()
        {
            UserId = user.Id,
            FirstName = user.FirstName ?? "",
            LastName = user.LastName ?? "",
            PhoneNumber = user.PhoneNumber ?? "",
            Address = user.Address ?? "",
            Email = user.Email ?? "",
        };
    }
}
