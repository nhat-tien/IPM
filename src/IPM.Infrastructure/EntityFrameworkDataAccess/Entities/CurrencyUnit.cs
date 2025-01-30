namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class CurrencyUnit: BaseEntity
{
    public int CurrencyUnitId { get; set; }
    public string? CurrencyUnitName { get; set; }

    public Domain.CurrencyUnit MapTo()
    {
        return new Domain.CurrencyUnit()
        {
            CurrencyUnitId = this.CurrencyUnitId,
            CurrencyUnitName = this.CurrencyUnitName,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
        };
    }

    public static CurrencyUnit MapFrom(Domain.CurrencyUnit model)
    {
        return new CurrencyUnit()
        {
            CurrencyUnitId = model.CurrencyUnitId,
            CurrencyUnitName = model.CurrencyUnitName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
