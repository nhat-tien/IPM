using IPM.Domain;

namespace IPM.Application.UseCases.User.UpdateUserInfoUseCase;

public class UpdateUserInfoRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? PositionId { get; set; }
    public int? AffiliatedUnitId { get; set; }
    public Sex Sex {get; set; }  
    public string? Address { get; set; }
    public string? AvatarUrl {get; set; }

    public Domain.User MapTo()
    {
        return new Domain.User()
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            PositionId = this.PositionId,
            AffiliatedUnitId = this.AffiliatedUnitId,
            PhoneNumber = this.PhoneNumber,
            Email = this.Email,
            Address = this.Address,
            Sex = this.Sex,
            AvatarUrl = this.AvatarUrl,
        };
    }
}
