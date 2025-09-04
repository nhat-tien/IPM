namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class AuditLog: BaseEntity 
{
    public int ProjectId {get; set;}
    public required string UserId {get; set;}

    public User? User {get; set;} 
    public Project? Project {get; set;} 

    public required string Activity {get; set;}
    public required string Description {get; set;}
}
