namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class FileType : BaseEntity
{
    public int FileTypeId { get; set; }
    public string? FileTypeName { get; set; }

    public Domain.FileType MapTo()
    {
        return new Domain.FileType()
        {
            FileTypeId = this.FileTypeId,
            FileTypeName = this.FileTypeName,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
        };
    }

    public static FileType MapFrom(Domain.FileType model)
    {
        return new FileType()
        {
            FileTypeId = model.FileTypeId,
            FileTypeName = model.FileTypeName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
