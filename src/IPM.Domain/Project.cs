namespace IPM.Domain;

//Vietnamese: Dự án 
public class Project
{
    public int ProjectId { get; set; }

    public string? ProjectNameEnglish { get; set; }

    public string? ProjectNameVietnamese { get; set; }

    public string? ProjectPurpose { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string? FundedEquipment { get; set; }

    public string? ProjectBudget { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string? ProjectProgress { get; set; }

    public string? PercentageOfProgress{ get; set; }

    public int? AffilatedUnitId { get; set; }
    public AffiliatedUnit? AffilatedUnit { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public int? SponsorId { get; set; }
    public Sponsor? Sponsor { get; set; }

    public int? AidTypeId { get; set; }
    public AidType? AidType { get; set; }

    public int? ApprovingAgencyId { get; set; }
    public ApprovingAgency? ApprovingAgency { get; set; }

    public int? CounterpartyId { get; set; }
    public Counterparty? Counterparty { get; set; }

    public int? CurrencyUnitId { get; set; }
    public CurrencyUnit? CurrencyUnit { get; set; }

    public string? OwnerId {get; set;}
    public User? Owner {get; set;}
}
