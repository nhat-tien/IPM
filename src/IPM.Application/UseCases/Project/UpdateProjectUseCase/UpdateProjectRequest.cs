
namespace IPM.Application.UseCases.Project.UpdateProjectUseCase;

public class UpdateProjectRequest
{
    public string? ProjectNameEnglish { get; set; }
    public string? ProjectNameVietnamese { get; set; }
    public string? ProjectPurpose { get; set; }
    public string? Content { get; set; }
    public string? FundedEquipment { get; set; }
    public string? ProjectBudget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsDeleted {get; set; }
    public bool IsReported {get; set; }
    public string? ProjectProgress { get; set; }
    public string? PercentageOfProgress { get; set; }
    public int? AffiliatedUnitId { get; set; }
    public int? CategoryId { get; set; }
    public int? SponsorId { get; set; }
    public int? AidTypeId { get; set; }
    public int? ApprovingAgencyId { get; set; }
    public int? CounterpartyId { get; set; }
    public int? CurrencyUnitId { get; set; }
    public required List<string> SetValueProperties {get; set;}
    public required string userId {get; set;}

    public Domain.Project MapTo()
    {
        return new Domain.Project()
        {
            ProjectNameEnglish = this.ProjectNameEnglish,
            ProjectNameVietnamese = this.ProjectNameVietnamese,
            ProjectPurpose = this.ProjectPurpose,
            ProjectBudget = this.ProjectBudget,
            Content = this.Content,
            FundedEquipment = this.FundedEquipment,
            StartDate = this.StartDate,
            EndDate = this.EndDate,
            ProjectProgress = this.ProjectProgress,
            IsDeleted = this.IsDeleted,
            IsReported = this.IsReported,
            PercentageOfProgress = this.PercentageOfProgress,
            AffiliatedUnitId = this.AffiliatedUnitId,
            CategoryId = this.CategoryId,
            SponsorId = this.SponsorId,
            AidTypeId = this.AidTypeId,
            ApprovingAgencyId = this.ApprovingAgencyId,
            CounterpartyId = this.CounterpartyId,
            CurrencyUnitId = this.CurrencyUnitId,
        };
    }
}
