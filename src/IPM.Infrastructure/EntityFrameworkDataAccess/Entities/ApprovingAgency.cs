namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class ApprovingAgency
{
    public int ApprovingAgencyId { get; set; }
    public string? ApprovingAgencyName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Domain.ApprovingAgency MapTo()
    {
        return new Domain.ApprovingAgency() 
        {
            ApprovingAgencyId = this.ApprovingAgencyId,
            ApprovingAgencyName = this.ApprovingAgencyName,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt
        };
    }

    public static ApprovingAgency MapFrom(Domain.ApprovingAgency model)
    {
        return new ApprovingAgency() 
        {
            ApprovingAgencyId = model.ApprovingAgencyId,
            ApprovingAgencyName = model.ApprovingAgencyName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
    }
}
