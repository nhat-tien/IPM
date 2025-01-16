using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class PositionRepository(AppDBContext context) : IPositionRepository
{
    public async Task Create(Domain.Position model)
    {
        var entity = Position.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await context.Positions.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await context.Positions.Where(e => e.PositionId == id).ExecuteDeleteAsync();
    }

    public async Task<Domain.Position?> FindById(int id)
    {
        Position? entity = await context.Positions.FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return entity.MapTo();
    }

    public async Task<IEnumerable<Domain.Position>> GetAll()
    {
        List<Position> entity = await context.Positions.ToListAsync();
        IEnumerable<Domain.Position> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task Update(Domain.Position model)
    {
        await context.Positions
            .Where(e => e.PositionId == model.PositionId)
            .ExecuteUpdateAsync(setter => 
                setter
                .SetProperty(e => e.PositionName, model.PositionName)
                .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
            );
    }
}
