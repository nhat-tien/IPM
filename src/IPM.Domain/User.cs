namespace IPM.Domain;

public class User
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? PositionId { get; set; }
    public int? AffiliatedUnitId { get; set; }
    public Sex Sex {get; set; }
    public string? PhoneNumber { get; set; }
    public string? AvatarUrl {get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Role? Role {get; set;}
    public Position? Position {get; set; } 
    public AffiliatedUnit? AffiliatedUnit {get; set;}

    //NOTE: I'm not sure about this property's type, maybe it's a string
    public int VerifiedCodeEmail { get; set; }

    public bool IsVerified { get; set; }
    public DateTime VerificationValidTime { get; set; }
    public List<Participation>? Participations {get; set;}

}
