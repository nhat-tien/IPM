using IPM.Application.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class RoleRepository(RoleManager<IdentityRole> roleManager) : IRoleRepository
{
    public async Task<List<IPM.Domain.Role>> GetAll()
    {
        List<IdentityRole> roles = await roleManager.Roles.ToListAsync();
        List<Domain.Role> roleDomain = roles.ConvertAll<Domain.Role>(role => new Domain.Role()
        {
            RoleId = role.Id,
            RoleName = role.Name ?? "",
        });
        return roleDomain;
    }

    public async Task<Domain.Role?> FindById(string roleId)
    {
        IdentityRole? role = await roleManager.FindByIdAsync(roleId);
        if (role is null)
        {
            return null;
        }
        return new Domain.Role() { RoleId = role.Id, RoleName = role.Name };
    }
}
