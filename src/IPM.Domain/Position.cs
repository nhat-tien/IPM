namespace IPM.Domain;

//Vietnamese: Chức vụ
public class Position
{
    public int PositionId { get; set; }
    public string? PositionName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
