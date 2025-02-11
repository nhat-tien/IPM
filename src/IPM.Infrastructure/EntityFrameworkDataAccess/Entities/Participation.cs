namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Participation: BaseEntity
{
    public int ProjectId {get; set;}
    public required string UserId {get; set;}
    public DateTime JoinDate { get; set;}
    public string? Status { get; set; }
    public string? Note { get; set; }
    public bool Owner { get; set; }

    public Domain.Participation MapTo()
    {
        return new Domain.Participation()
        {
            ProjectId = this.ProjectId,
            UserId = this.UserId,
            Owner = this.Owner,
            Status = this.Status,
            Note = this.Note,
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
            Owner = model.Owner,
            Status = model.Status,
            Note = model.Note,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
            JoinDate = model.JoinDate
        };
    }
}

