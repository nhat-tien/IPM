using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class CatalogueRepository(AppDBContext context): ICatalogueRepository
{
    public async Task Create(Domain.Catalogue model)
    {
        var entity = Catalogue.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await context.Catalogues.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await context.Catalogues.Where(e => e.CatalogueId == id).ExecuteDeleteAsync();
    }

    public async Task<Domain.Catalogue?> FindById(int id)
    {
        Catalogue? entity = await context.Catalogues.FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return entity.MapTo();
    }

    public async Task<IEnumerable<Domain.Catalogue>> GetAll()
    {
        List<Catalogue> entity = await context.Catalogues.ToListAsync();
        IEnumerable<Domain.Catalogue> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task Update(Domain.Catalogue model)
    {
        await context.Catalogues
            .Where(e => e.CatalogueId == model.CatalogueId)
            .ExecuteUpdateAsync(setter => 
                setter
                .SetProperty(e => e.CatalogueName, model.CatalogueName)
                .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
            );
    }
}
