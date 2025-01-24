namespace IPM.Application.UseCases.Project.CreateProjectUseCase;

public class CreateProjectRequest
{
    public string? ProjectNameEnglish { get; set; }
    public string? ProjectNameVietnamese { get; set; }
    public string? ProjectPurpose { get; set; }
    public string? Content { get; set; }
    public string? FundedEquipment { get; set; }
    public string? ProjectBudget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? ProjectProgress { get; set; }
    public string? PercentageOfProgress { get; set; }
    public int? AffilatedUnitId { get; set; }
    public int? CategoryId { get; set; }
    public int? SponsorId { get; set; }
    public int? AidTypeId { get; set; }
    public int? ApprovingAgencyId { get; set; }
    public int? CounterpartyId { get; set; }
    public int? CurrencyUnitId { get; set; }
    public string? OwnerId { get; set; }
}
