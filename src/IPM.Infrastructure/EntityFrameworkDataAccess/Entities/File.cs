namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class File : BaseEntity
{
    public int FileId { get; set; }
    public string? FileName { get; set; }
    public string? ObjectName { get; set; }

    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public int? FileTypeId { get; set; }
    public FileType? FileType { get; set; }

    public Domain.File MapTo()
    {
        return new Domain.File()
        {
            FileId = this.FileId,
            FileName = this.FileName,
            ProjectId = this.ProjectId,
            FileTypeId = this.FileTypeId,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
        };
    }

    public static File MapFrom(Domain.File model)
    {
        return new File()
        {
            FileId = model.FileId,
            FileName = model.FileName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
