namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class AffiliatedUnit: BaseEntity
{
    public int AffiliatedUnitId { get; set; }
    public string? AffiliatedUnitName { get; set; }

    public Domain.AffiliatedUnit MapTo()
    {
        return new Domain.AffiliatedUnit()
        {
            AffiliatedUnitId = this.AffiliatedUnitId,
            AffiliatedUnitName = this.AffiliatedUnitName,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
        };
    }

    public static AffiliatedUnit MapFrom(Domain.AffiliatedUnit model)
    {
        return new AffiliatedUnit()
        {
            AffiliatedUnitId = model.AffiliatedUnitId,
            AffiliatedUnitName = model.AffiliatedUnitName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
