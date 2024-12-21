namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

//TODO: add more: Avatar
public class User
{
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int PositionId { get; set; }
    public int AffilatedUnitId { get; set;}
    public int RoleId { get; set; }
    public string? PhoneNumber { get; set;}
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Password {get; set;}
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    //NOTE: I'm not sure about this property's type, maybe it's a string
    public int VerifiedCodeEmail { get; set; }

    public int VerifiedStatus { get; set; }
    public DateTime VerificationValidTime {get; set;}
}
