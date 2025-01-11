using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class AffiliatedUnitRepository(AppDBContext context): IAffiliatedUnitRepository
{
    public async Task Create(Domain.AffiliatedUnit model)
    {
        var entity = AffiliatedUnit.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        await context.AffiliatedUnits.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await context.AffiliatedUnits.Where(e => e.AffiliatedUnitId == id).ExecuteDeleteAsync();
    }

    public async Task<Domain.AffiliatedUnit?> FindById(int id)
    {
        AffiliatedUnit? entity = await context.AffiliatedUnits.FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return entity.MapTo();
    }

    public async Task<IEnumerable<Domain.AffiliatedUnit>> GetAll()
    {
        List<AffiliatedUnit> entity = await context.AffiliatedUnits.ToListAsync();
        IEnumerable<Domain.AffiliatedUnit> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task Update(int id, Domain.AffiliatedUnit model)
    {
        await context.AffiliatedUnits
            .Where(e => e.AffiliatedUnitId == id)
            .ExecuteUpdateAsync(setter => 
                setter
                .SetProperty(e => e.AffiliatedUnitName, model.AffiliatedUnitName)
                .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
            );
    }
}
