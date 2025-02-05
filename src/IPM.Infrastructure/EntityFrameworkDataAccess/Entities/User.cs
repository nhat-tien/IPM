using Microsoft.AspNetCore.Identity;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

//TODO: add more: Avatar
public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? PositionId { get; set; }
    public int? AffilatedUnitId { get; set; }
    public string? Address { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    //NOTE: I'm not sure about this property's type, maybe it's a string
    public int VerifiedCodeEmail { get; set; }
    public int VerifiedStatus { get; set; }
    public DateTime VerificationValidTime { get; set; }

    public Position? Position {get; set; } 
    public AffiliatedUnit? AffilatedUnit { get; set; }

    public List<Project>? Projects { get; set; }
    public List<Participation>? Participations { get; set; }

    public Domain.User MapTo()
    {
        return new Domain.User()
        {
            UserId = this.Id,
            UserName = this.UserName,
            FirstName = this.FirstName,
            LastName = this.LastName,
            PositionId = this.PositionId,
            AffilatedUnitId = this.AffilatedUnitId,
            Email = this.Email,
            Address = this.Address,
            Status = this.Status,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
            VerifiedCodeEmail = this.VerifiedCodeEmail,
            VerifiedStatus = this.VerifiedStatus,
            VerificationValidTime = this.VerificationValidTime,
        };
    }

    public static User MapFrom(Domain.User user)
    {
        if (user.UserId is null)
        {
            return new User()
            {
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
                VerificationValidTime = user.VerificationValidTime,
            };
        }
        else
        {
            return new User()
            {
                Id = user.UserId,
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
                VerificationValidTime = user.VerificationValidTime,
            };
        }
    }
}
