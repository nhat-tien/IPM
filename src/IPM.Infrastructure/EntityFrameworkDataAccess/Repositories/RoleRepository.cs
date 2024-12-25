using IPM.Application.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly RoleManager<IdentityRole> roleManager;

    public RoleRepository(RoleManager<IdentityRole> roleManager)
    {
        this.roleManager = roleManager;
    }

    public async Task<List<IPM.Domain.Role>> GetAll()
    {
        var roles = await roleManager.Roles.ToListAsync();
        var roleDomain = new List<IPM.Domain.Role>();
        foreach (var role in roles)
        {
            roleDomain.Add(new IPM.Domain.Role(role.Id, role.Name ?? ""));
        }
        return roleDomain;
    }
}
