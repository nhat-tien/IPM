using Microsoft.AspNetCore.Identity;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Role: IdentityRole
{    
    public int RoleId { get; set; }
    public string? RoleName { get; set; }
    public DateTime CreatedAt { get; set; }
}
