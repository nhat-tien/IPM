namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class AuditLog: BaseEntity 
{
    public int AuditLogId { get; set; }

    public int ProjectId {get; set;}
    public required string UserId {get; set;}

    public User? User {get; set;} 
    public Project? Project {get; set;} 

    public required string Activity {get; set;}
    public required string Description {get; set;}


    public Domain.AuditLog MapTo()
    {
        return new Domain.AuditLog()
        {
            AuditLogId = this.AuditLogId,
            ProjectId = this.ProjectId,
            UserId = this.UserId,
            Activity = this.Activity,
            Description = this.Description,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
        };
    }

    public static AuditLog MapFrom(Domain.AuditLog model)
    {
        return new AuditLog()
        {
            AuditLogId = model.AuditLogId,
            ProjectId = model.ProjectId,
            UserId = model.UserId,
            Activity = model.Activity,
            Description = model.Description,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
