using IPM.Application.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class RoleRepository(RoleManager<IdentityRole> roleManager) : IRoleRepository
{
    public async Task<List<IPM.Domain.Role>> GetAll()
    {
        var roles = await roleManager.Roles.ToListAsync();
        var roleDomain = new List<IPM.Domain.Role>();
        foreach (var role in roles)
        {
            roleDomain.Add(new Domain.Role(role.Id, role.Name ?? ""));
        }
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
