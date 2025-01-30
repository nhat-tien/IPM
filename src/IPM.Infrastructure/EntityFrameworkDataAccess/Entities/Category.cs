namespace IPM.Infrastructure.EntityFrameworkDataAccess.Entities;

public class Category: BaseEntity
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }

    public Domain.Category MapTo() 
    {
        return new Domain.Category() 
        {
            CategoryId = this.CategoryId,
            CategoryName = this.CategoryName,
            CreatedAt = this.CreatedAt,
            UpdatedAt = this.UpdatedAt
        };
    }

    public static Category MapFrom(Domain.Category model)
    {
        return new Category()
        {
            CategoryId = model.CategoryId,
            CategoryName = model.CategoryName,
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
    }
}
