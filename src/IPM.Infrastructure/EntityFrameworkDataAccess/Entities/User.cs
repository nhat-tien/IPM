using System.ComponentModel;
using IPM.Domain;
using Microsoft.AspNetCore.Identity;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

//TODO: add more: Avatar
public class User : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? PositionId { get; set; }

    public int? AffiliatedUnitId { get; set; }

    public Sex Sex {get; set; }  

    public string? Address { get; set; }

    public string? AvatarUrl {get; set; }

    public int Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    //NOTE: I'm not sure about this property's type, maybe it's a string
    public int VerifiedCodeEmail { get; set; }

    [DefaultValue(false)]
    public bool IsVerified { get; set; }

    public DateTime VerificationValidTime { get; set; }

    public Position? Position { get; set; }

    public AffiliatedUnit? AffiliatedUnit { get; set; }

    public List<Participation>? Participations {get; set;}

    public virtual ICollection<IdentityUserClaim<string>>? Claims { get; set; }
    public virtual ICollection<IdentityUserLogin<string>>? Logins { get; set; }
    public virtual ICollection<IdentityUserToken<string>>? Tokens { get; set; }
    public virtual List<UserRole>? UserRoles { get; set; }

    public Domain.User MapTo()
    {
        return new Domain.User()
        {
            UserId = this.Id,
            UserName = this.UserName,
            FirstName = this.FirstName,
            LastName = this.LastName,
            PositionId = this.PositionId,
            PhoneNumber = this.PhoneNumber,
            AffiliatedUnitId = this.AffiliatedUnitId,
            Email = this.Email,
            Address = this.Address,
            Status = this.Status,
            Sex = this.Sex,
            AvatarUrl = this.AvatarUrl,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
            VerifiedCodeEmail = this.VerifiedCodeEmail,
            IsVerified = this.IsVerified,
            VerificationValidTime = this.VerificationValidTime,
            Role = this.UserRoles is not null ? this.UserRoles[0].Role!.MapTo() : null,
            AffiliatedUnit = this.AffiliatedUnit is not null ? this.AffiliatedUnit.MapTo() : null,
            Position = this.Position is not null ? this.Position.MapTo() : null,
            Participations = this.Participations is not null
                ? Participations.Select(e => e.MapToWithProject()).ToList()
                : null,
        };
    }
    public Domain.User MapToWithOutParticipations()
    {
        return new Domain.User()
        {
            UserId = this.Id,
            UserName = this.UserName,
            FirstName = this.FirstName,
            LastName = this.LastName,
            PositionId = this.PositionId,
            PhoneNumber = this.PhoneNumber,
            AffiliatedUnitId = this.AffiliatedUnitId,
            Email = this.Email,
            Address = this.Address,
            Status = this.Status,
            Sex = this.Sex,
            AvatarUrl = this.AvatarUrl,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
            VerifiedCodeEmail = this.VerifiedCodeEmail,
            IsVerified = this.IsVerified,
            VerificationValidTime = this.VerificationValidTime,
            Role = this.UserRoles is not null ? this.UserRoles[0].Role!.MapTo() : null,
            AffiliatedUnit = this.AffiliatedUnit is not null ? this.AffiliatedUnit.MapTo() : null,
            Position = this.Position is not null ? this.Position.MapTo() : null,
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
                AffiliatedUnitId = user.AffiliatedUnitId,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Sex = user.Sex,
                Address = user.Address,
                Status = user.Status,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                VerifiedCodeEmail = user.VerifiedCodeEmail,
                IsVerified = user.IsVerified,
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
                PhoneNumber = user.PhoneNumber,
                AffiliatedUnitId = user.AffiliatedUnitId,
                Email = user.Email,
                Sex = user.Sex,
                Address = user.Address,
                Status = user.Status,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                VerifiedCodeEmail = user.VerifiedCodeEmail,
                IsVerified = user.IsVerified,
                VerificationValidTime = user.VerificationValidTime,
            };
        }
    }
}
