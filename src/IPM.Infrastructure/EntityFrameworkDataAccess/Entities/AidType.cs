namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class AidType
{
    public int AidTypeId { get; set; }
    public string? AidTypeName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
