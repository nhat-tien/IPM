namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class AidType
{
    public int AidTypeId { get; set; }
    public string? AidTypeName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Domain.AidType MapTo()
    {
        return new Domain.AidType()
        {
            AidTypeId = this.AidTypeId,
            AidTypeName = this.AidTypeName,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
        };
    }

    public static AidType MapFrom(Domain.AidType model)
    {
        return new AidType()
        {
            AidTypeId = model.AidTypeId,
            AidTypeName = model.AidTypeName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
