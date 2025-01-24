using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class AidTypeRepository(AppDBContext context): IAidTypeRepository
{
    public async Task Create(Domain.AidType model)
    {
        var entity = AidType.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await context.AidTypes.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await context.AidTypes.Where(e => e.AidTypeId == id).ExecuteDeleteAsync();
    }

    public async Task<Domain.AidType?> FindById(int id)
    {
        AidType? entity = await context.AidTypes.FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return entity.MapTo();
    }

    public async Task<IEnumerable<Domain.AidType>> GetAll()
    {
        List<AidType> entity = await context.AidTypes.ToListAsync();
        IEnumerable<Domain.AidType> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task Update(Domain.AidType model)
    {
        await context.AidTypes
            .Where(e => e.AidTypeId == model.AidTypeId)
            .ExecuteUpdateAsync(setter => 
                setter
                .SetProperty(e => e.AidTypeName, model.AidTypeName)
                .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
            );
    }

}
