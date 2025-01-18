using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class CounterpartyRepository(AppDBContext context) : ICounterpartyRepository
{
    public async Task Create(Domain.Counterparty model)
    {
        var entity = Counterparty.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await context.Counterparties.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await context.Counterparties.Where(e => e.CounterpartyId == id).ExecuteDeleteAsync();
    }

    public async Task<Domain.Counterparty?> FindById(int id)
    {
        Counterparty? entity = await context.Counterparties.FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return entity.MapTo();
    }

    public async Task<IEnumerable<Domain.Counterparty>> GetAll()
    {
        List<Counterparty> entity = await context.Counterparties.ToListAsync();
        IEnumerable<Domain.Counterparty> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task Update(Domain.Counterparty model)
    {
        await context.Counterparties
            .Where(e => e.CounterpartyId == model.CounterpartyId)
            .ExecuteUpdateAsync(setter => 
                setter
                .SetProperty(e => e.CounterpartyName, model.CounterpartyName)
                .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
            );
    }
}
