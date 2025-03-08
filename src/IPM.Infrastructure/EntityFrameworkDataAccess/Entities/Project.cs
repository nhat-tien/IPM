namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Project : BaseEntity
{
    public int ProjectId { get; set; }

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

    public int? AffiliatedUnitId { get; set; }
    public AffiliatedUnit? AffiliatedUnit { get; set; }

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

    // public List<User>? Users { get; set; }
    public List<Participation>? Participations { get; set; }
    public List<File>? Files { get; set; }


    public Domain.Project MapTo()
    {
        return new Domain.Project()
        {
            ProjectId = this.ProjectId,
            ProjectNameEnglish = this.ProjectNameEnglish,
            ProjectNameVietnamese = this.ProjectNameVietnamese,
            ProjectPurpose = this.ProjectPurpose,
            ProjectBudget = this.ProjectBudget,
            Content = this.Content,
            FundedEquipment = this.FundedEquipment,
            StartDate = this.StartDate,
            EndDate = this.EndDate,
            ProjectProgress = this.ProjectProgress,
            PercentageOfProgress = this.PercentageOfProgress,
            AffiliatedUnitId = this.AffiliatedUnitId,
            AffiliatedUnit = this.AffiliatedUnit is not null ? AffiliatedUnit.MapTo() : null,
            CategoryId = this.CategoryId,
            Category = this.Category is not null ? Category.MapTo() : null,
            SponsorId = this.SponsorId,
            Sponsor = this.Sponsor is not null ? Sponsor.MapTo() : null,
            AidTypeId = this.AidTypeId,
            AidType = this.AidType is not null ? AidType.MapTo() : null,
            ApprovingAgencyId = this.ApprovingAgencyId,
            ApprovingAgency = this.ApprovingAgency is not null ? ApprovingAgency.MapTo() : null,
            CounterpartyId = this.CounterpartyId,
            Counterparty = this.Counterparty is not null ? Counterparty.MapTo() : null,
            CurrencyUnitId = this.CurrencyUnitId,
            CurrencyUnit = this.CurrencyUnit is not null ? CurrencyUnit.MapTo() : null,
            // Users = this.Users is not null ? Users.Select(e => e.MapTo()).ToList(): null,
            Files = this.Files is not null ? this.Files.Select(e => e.MapTo()).ToList() : null,
            Participations = this.Participations is not null
                ? Participations.Select(e => e.MapToWithUser()).ToList()
                : null,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
        };
    }
    public Domain.Project MapToWithOutParticipations()
    {
        return new Domain.Project()
        {
            ProjectId = this.ProjectId,
            ProjectNameEnglish = this.ProjectNameEnglish,
            ProjectNameVietnamese = this.ProjectNameVietnamese,
            ProjectPurpose = this.ProjectPurpose,
            ProjectBudget = this.ProjectBudget,
            Content = this.Content,
            FundedEquipment = this.FundedEquipment,
            StartDate = this.StartDate,
            EndDate = this.EndDate,
            ProjectProgress = this.ProjectProgress,
            PercentageOfProgress = this.PercentageOfProgress,
            AffiliatedUnitId = this.AffiliatedUnitId,
            AffiliatedUnit = this.AffiliatedUnit is not null ? AffiliatedUnit.MapTo() : null,
            CategoryId = this.CategoryId,
            Category = this.Category is not null ? Category.MapTo() : null,
            SponsorId = this.SponsorId,
            Sponsor = this.Sponsor is not null ? Sponsor.MapTo() : null,
            AidTypeId = this.AidTypeId,
            AidType = this.AidType is not null ? AidType.MapTo() : null,
            ApprovingAgencyId = this.ApprovingAgencyId,
            ApprovingAgency = this.ApprovingAgency is not null ? ApprovingAgency.MapTo() : null,
            CounterpartyId = this.CounterpartyId,
            Counterparty = this.Counterparty is not null ? Counterparty.MapTo() : null,
            CurrencyUnitId = this.CurrencyUnitId,
            CurrencyUnit = this.CurrencyUnit is not null ? CurrencyUnit.MapTo() : null,
            // Users = this.Users is not null ? Users.Select(e => e.MapTo()).ToList(): null,
            Files = this.Files is not null ? this.Files.Select(e => e.MapTo()).ToList() : null,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
        };
    }

    public static Project MapFrom(Domain.Project model)
    {
        return new Project()
        {
            ProjectNameEnglish = model.ProjectNameEnglish,
            ProjectNameVietnamese = model.ProjectNameVietnamese,
            ProjectPurpose = model.ProjectPurpose,
            ProjectBudget = model.ProjectBudget,
            Content = model.Content,
            FundedEquipment = model.FundedEquipment,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            ProjectProgress = model.ProjectProgress,
            PercentageOfProgress = model.PercentageOfProgress,
            AffiliatedUnitId = model.AffiliatedUnitId,
            CategoryId = model.CategoryId,
            SponsorId = model.SponsorId,
            AidTypeId = model.AidTypeId,
            ApprovingAgencyId = model.ApprovingAgencyId,
            CounterpartyId = model.CounterpartyId,
            CurrencyUnitId = model.CurrencyUnitId,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
