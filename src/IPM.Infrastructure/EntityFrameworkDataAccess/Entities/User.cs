using Microsoft.AspNetCore.Identity;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

//TODO: add more: Avatar
public class User: IdentityUser
{
    public required int UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int PositionId { get; set; }
    public required int AffilatedUnitId { get; set;}
    // public int RoleId { get; set; }
    // public string? PhoneNumber { get; set;}
    public required string Address { get; set; }
    // public string? Email { get; set; }
    public required string Password {get; set;}
    public required int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    // public Role? Role {get; set;}

    //NOTE: I'm not sure about this property's type, maybe it's a string
    public int VerifiedCodeEmail { get; set; }

    public int VerifiedStatus { get; set; }
    public DateTime VerificationValidTime {get; set;}
}
