using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class CurrencyUnitRepository(AppDBContext context): ICurrencyUnitRepository
{
    public async Task Create(Domain.CurrencyUnit model)
    {
        var entity = CurrencyUnit.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        await context.CurrencyUnits.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await context.CurrencyUnits.Where(e => e.CurrencyUnitId == id).ExecuteDeleteAsync();
    }

    public async Task<Domain.CurrencyUnit?> FindById(int id)
    {
        CurrencyUnit? entity = await context.CurrencyUnits.FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return entity.MapTo();
    }

    public async Task<IEnumerable<Domain.CurrencyUnit>> GetAll()
    {
        List<CurrencyUnit> entity = await context.CurrencyUnits.ToListAsync();
        IEnumerable<Domain.CurrencyUnit> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task Update(int id, Domain.CurrencyUnit model)
    {
        await context.CurrencyUnits
            .Where(e => e.CurrencyUnitId == id)
            .ExecuteUpdateAsync(setter => 
                setter
                .SetProperty(e => e.CurrencyUnitName, model.CurrencyUnitName)
                .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
            );
    }
}
