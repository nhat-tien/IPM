namespace IPM.Domain;


//Vietnamese: Đơn vị liên kết
public class AffiliatedUnit
{
    public int AffiliatedUnitId { get; set; }
    public string? AffiliatedUnitName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
