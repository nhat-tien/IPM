
namespace IPM.Domain;

public class File
{
    public int FileId { get; set; }
    public string? FileName { get; set; }
    public string? ObjectName { get; set; }
    public string? Url { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted {get; set; }

    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public int? FileTypeId { get; set; }
    public FileType? FileType { get; set; }

    public required string UserId { get; set; }
    public User? User {get; set;} 
}
