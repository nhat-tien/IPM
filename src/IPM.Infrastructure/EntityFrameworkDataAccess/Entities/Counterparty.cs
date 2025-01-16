namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Counterparty
{
    public int CounterpartyId { get; set; }
    public string? CounterpartyName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Domain.Counterparty MapTo()
    {
        return new Domain.Counterparty()
        {
            CounterpartyId = this.CounterpartyId,
            CounterpartyName = this.CounterpartyName,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt
        };
    }

    public static Counterparty MapFrom(Domain.Counterparty model)
    {
        return new Counterparty()
        {
            CounterpartyId = model.CounterpartyId,
            CounterpartyName = model.CounterpartyName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
    }
}
