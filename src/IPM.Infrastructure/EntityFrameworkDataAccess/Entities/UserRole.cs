using Microsoft.AspNetCore.Identity;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class UserRole: IdentityUserRole<string>
{
   public virtual User? User { get; set; }
    public virtual Role? Role { get; set; }
}
