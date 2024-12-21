namespace IPM.Infrastructure.Entities;

public class Participation
{
    public int ParticipationId { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public DateTime JoinDate { get; set;}
    public string? Status { get; set; }
    public string? Note { get; set; }
}

