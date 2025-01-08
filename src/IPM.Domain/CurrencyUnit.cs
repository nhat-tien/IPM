namespace IPM.Domain;

//Vietnamese: Đơn vị tiền tệ 
public class CurrencyUnit
{
    public int CurrencyUnitId { get; set; }
    public string? CurrencyUnitName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
