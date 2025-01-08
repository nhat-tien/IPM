namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Catalogue
{
    public int CatalogueId { get; set; }
    public string? CatalogueName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Domain.Catalogue MapTo() 
    {
        return new Domain.Catalogue() 
        {
            CatalogueId = this.CatalogueId,
            CatalogueName = this.CatalogueName,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt
        };
    }

    public static Catalogue MapFrom(Domain.Catalogue model)
    {
        return new Catalogue()
        {
            CatalogueId = model.CatalogueId,
            CatalogueName = model.CatalogueName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
    }
}
