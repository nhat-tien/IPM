using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class CategoryRepository : GenericRepository<Domain.Category, Category>, ICategoryRepository
{
    public CategoryRepository(AppDBContext ctx) : base(ctx)
    {
    }

    public override int GetDomainId(Domain.Category domain)
    {
        return domain.CategoryId;
    }

    public override IQueryable<Category> WhereId(int id)
    {
        return context.Categories.Where(e => e.CategoryId == id);
    }

    public override Category MapFromDomain(Domain.Category domain)
    {
        return Category.MapFrom(domain);
    }

    public override Domain.Category MapToDomain(Category entity)
    {
        return entity.MapTo();
    }
}
