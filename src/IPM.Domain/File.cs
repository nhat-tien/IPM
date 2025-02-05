namespace IPM.Domain;

public class File
{
    public int FileId { get; set; }
    public string? FileName { get; set; }
    public string? Url { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public int? FileTypeId { get; set; }
    public FileType? FileType { get; set; }
}
