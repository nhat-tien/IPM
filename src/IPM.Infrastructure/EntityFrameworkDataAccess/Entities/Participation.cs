namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Participation: BaseEntity
{
    public int ProjectId {get; set;}
    public required string UserId {get; set;}
    public DateTime JoinDate { get; set;}
    public string? Status { get; set; }
    public string? Note { get; set; }
    public string? Role { get; set; }

    public User? User {get; set;} 
    public Project? Project {get; set;} 

    public Domain.Participation MapTo()
    {
        return new Domain.Participation()
        {
            ProjectId = this.ProjectId,
            UserId = this.UserId,
            Status = this.Status,
            Note = this.Note,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
            JoinDate = this.JoinDate,
            Role = this.Role
        };
    }

    public Domain.Participation MapToWithUser()
    {
        return new Domain.Participation()
        {
            ProjectId = this.ProjectId,
            UserId = this.UserId,
            Status = this.Status,
            Note = this.Note,
            User = this.User is not null ? this.User.MapToWithOutParticipations(): null,
            Role = this.Role,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
            JoinDate = this.JoinDate
        };
    }

    public Domain.Participation MapToWithProject()
    {
        return new Domain.Participation()
        {
            ProjectId = this.ProjectId,
            UserId = this.UserId,
            Status = this.Status,
            Note = this.Note,
            Project = this.Project is not null ? this.Project.MapToWithOutParticipations(): null,
            Role = this.Role,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
            JoinDate = this.JoinDate
        };
    }

    public static Participation MapFrom(Domain.Participation model)
    {
        return new Participation()
        {
            ProjectId = model.ProjectId,
            UserId = model.UserId,
            Status = model.Status,
            Note = model.Note,
            Role = model.Role,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            JoinDate = model.JoinDate
        };
    }
}

