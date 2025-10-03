namespace IPM.Domain;

public class AuditLog
{
    public int AuditLogId { get; set; }

    public int ProjectId {get; set;}
    public required string UserId {get; set;}

    public User? User {get; set;} 
    public Project? Project {get; set;} 

    public required string Activity {get; set;}
    public required string Description {get; set;}

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
