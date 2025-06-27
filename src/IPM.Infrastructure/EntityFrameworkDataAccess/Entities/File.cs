using System.ComponentModel;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class File : BaseEntity
{
    public int FileId { get; set; }
    public string? FileName { get; set; }
    public string? ObjectName { get; set; }

    [DefaultValue(false)]
    public bool IsDeleted {get; set; }

    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public int? FileTypeId { get; set; }
    public FileType? FileType { get; set; }

    public required string UserId { get; set; }
    public User? User {get; set;} 

    public Domain.File MapTo()
    {
        return new Domain.File()
        {
            FileId = this.FileId,
            FileName = this.FileName,
            ProjectId = this.ProjectId,
            FileTypeId = this.FileTypeId,
            ObjectName = this.ObjectName,
            UserId = this.UserId,
            FileType = this.FileType is not null ? this.FileType.MapTo() : null,
            User = this.User is not null ? this.User.MapTo(): null,
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
            ProjectId = model.ProjectId,
            FileTypeId = model.FileTypeId,
            UserId = model.UserId,
            ObjectName = model.ObjectName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
