namespace IPM.Domain;

public class Participation
{
    public int ProjectId { get; set; }
    public required string UserId { get; set; }
    public DateTime JoinDate { get; set;}
    public string? Status { get; set; }
    public string? Note { get; set; }
    public string? Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public User? User {get; set;} 

    public Project? Project {get; set;} 
}
