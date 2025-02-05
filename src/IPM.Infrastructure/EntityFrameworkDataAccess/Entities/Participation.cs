namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Participation
{
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public DateTime JoinDate { get; set;}
    public string? Status { get; set; }
    public string? Note { get; set; }
    public bool Owner { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

