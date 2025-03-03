using Microsoft.AspNetCore.Identity;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Role : IdentityRole
{
    public virtual ICollection<UserRole>? UserRoles { get; set; }

    public Domain.Role MapTo()
    {
        return new Domain.Role()
        {
            RoleId = this.Id,
            RoleName = this.Name
        };
    }
}
