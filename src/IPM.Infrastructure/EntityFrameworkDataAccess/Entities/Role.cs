using Microsoft.AspNetCore.Identity;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Role: IdentityRole
{
    public virtual ICollection<UserRole>? UserRoles { get; set; }
}
