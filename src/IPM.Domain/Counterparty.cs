namespace IPM.Domain;

//Vietnamese: Đối tác thực hiện
public class Counterparty
{
    public int CounterpartyId { get; set; }
    public string? CounterpartyName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
