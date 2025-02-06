using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class RoleRepository(AppDBContext ctx) : IRoleRepository
{
    public async Task<List<IPM.Domain.Role>> GetAll()
    {
        List<Role> roles = await ctx.Roles.ToListAsync();
        List<Domain.Role> roleDomain = roles.ConvertAll<Domain.Role>(role => new Domain.Role()
        {
            RoleId = role.Id,
            RoleName = role.Name ?? "",
        });
        return roleDomain;
    }

    public async Task<Domain.Role?> FindById(string roleId)
    {
        Role? role = await ctx.Roles.Where(e => e.Id == roleId).FirstOrDefaultAsync();
        if (role is null)
        {
            return null;
        }
        return new Domain.Role() { RoleId = role.Id, RoleName = role.Name };
    }
}
