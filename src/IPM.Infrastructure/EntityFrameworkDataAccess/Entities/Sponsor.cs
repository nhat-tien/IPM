namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Sponsor
{
    public int SponsorId { get; set; }
    public string? SponsorName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
