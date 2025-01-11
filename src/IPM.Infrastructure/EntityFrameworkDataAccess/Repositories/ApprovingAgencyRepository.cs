using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class ApprovingAgencyRepository(AppDBContext context): IApprovingAgencyRepository
{
    public async Task Create(Domain.ApprovingAgency model)
    {
        var entity = ApprovingAgency.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await context.ApprovingAgencies.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await context.ApprovingAgencies.Where(e => e.ApprovingAgencyId == id).ExecuteDeleteAsync();
    }

    public async Task<Domain.ApprovingAgency?> FindById(int id)
    {
        ApprovingAgency? entity = await context.ApprovingAgencies.FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return entity.MapTo();
    }

    public async Task<IEnumerable<Domain.ApprovingAgency>> GetAll()
    {
        List<ApprovingAgency> entity = await context.ApprovingAgencies.ToListAsync();
        IEnumerable<Domain.ApprovingAgency> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task Update(int id, Domain.ApprovingAgency model)
    {
        await context.ApprovingAgencies
            .Where(e => e.ApprovingAgencyId == id)
            .ExecuteUpdateAsync(setter => 
                setter
                .SetProperty(e => e.ApprovingAgencyName, model.ApprovingAgencyName)
                .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
            );
    }
}
