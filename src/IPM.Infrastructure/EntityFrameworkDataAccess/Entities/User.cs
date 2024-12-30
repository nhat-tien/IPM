using Microsoft.AspNetCore.Identity;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

//TODO: add more: Avatar
public class User: IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int PositionId { get; set; }
    public int AffilatedUnitId { get; set;}
    public string? Address { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    //NOTE: I'm not sure about this property's type, maybe it's a string
    public int VerifiedCodeEmail { get; set; }

    public int VerifiedStatus { get; set; }
    public DateTime VerificationValidTime {get; set;}

    public Domain.User MapTo() 
    {
        return new Domain.User() 
        {
            UserId = Id,
            UserName = UserName,
            FirstName = FirstName,
            LastName = LastName,
            PositionId = PositionId,
            AffilatedUnitId = AffilatedUnitId,
            Email = Email,
            Address = Address,
            Status = Status,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            VerifiedCodeEmail = VerifiedCodeEmail,
            VerifiedStatus = VerifiedStatus,
            VerificationValidTime = VerificationValidTime
        };
    }

    public static User MapFrom(Domain.User user)
    {
        return new User() {
            Id = user.UserId ?? "",
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PositionId = user.PositionId,
            AffilatedUnitId = user.AffilatedUnitId,
            Email = user.Email,
            Address = user.Address,
            Status = user.Status,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            VerifiedCodeEmail = user.VerifiedCodeEmail,
            VerifiedStatus = user.VerifiedStatus,
            VerificationValidTime = user.VerificationValidTime
        };
    }
}
