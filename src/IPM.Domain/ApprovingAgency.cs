namespace IPM.Domain;


//Vietnamese: Cơ quan phê duyệt 
public class ApprovingAgency
{
    public int ApprovingAgencyId { get; set; }
    public string? ApprovingAgencyName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
