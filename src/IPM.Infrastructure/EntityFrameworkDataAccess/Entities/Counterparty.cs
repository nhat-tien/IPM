namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Counterparty
{
    public int CounterpartyId { get; set; }
    public string? CounterpartyName { get; set; }
    public DateTime CreatedAt { get; set; }
}
