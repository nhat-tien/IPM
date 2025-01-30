namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Sponsor: BaseEntity
{
    public int SponsorId { get; set; }
    public string? SponsorName { get; set; }

    public Domain.Sponsor MapTo()
    {
        return new Domain.Sponsor()
        {
            SponsorId = this.SponsorId,
            SponsorName = this.SponsorName,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt,
        };
    }

    public static Sponsor MapFrom(Domain.Sponsor model)
    {
        return new Sponsor()
        {
            SponsorId = model.SponsorId,
            SponsorName = model.SponsorName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt,
        };
    }
}
