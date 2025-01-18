using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class CategoryRepository(AppDBContext context): ICategoryRepository
{
    public async Task Create(Domain.Category model)
    {
        var entity = Category.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await context.Categories.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await context.Categories.Where(e => e.CategoryId == id).ExecuteDeleteAsync();
    }

    public async Task<Domain.Category?> FindById(int id)
    {
        Category? entity = await context.Categories.FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return entity.MapTo();
    }

    public async Task<IEnumerable<Domain.Category>> GetAll()
    {
        List<Category> entity = await context.Categories.ToListAsync();
        IEnumerable<Domain.Category> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task Update(Domain.Category model)
    {
        await context.Categories
            .Where(e => e.CategoryId == model.CategoryId)
            .ExecuteUpdateAsync(setter => 
                setter
                .SetProperty(e => e.CategoryName, model.CategoryName)
                .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
            );
    }
}
