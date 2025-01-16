using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class SponsorRepository(AppDBContext context) : ISponsorRepository
{
    public async Task Create(Domain.Sponsor model)
    {
        var entity = Sponsor.MapFrom(model);
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await context.Sponsors.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await context.Sponsors.Where(e => e.SponsorId == id).ExecuteDeleteAsync();
    }

    public async Task<Domain.Sponsor?> FindById(int id)
    {
        Sponsor? entity = await context.Sponsors.FindAsync(id);
        if(entity is null) 
        {
            return null;
        }
        return entity.MapTo();
    }

    public async Task<IEnumerable<Domain.Sponsor>> GetAll()
    {
        List<Sponsor> entity = await context.Sponsors.ToListAsync();
        IEnumerable<Domain.Sponsor> listOfDomain = entity.Select(entity => entity.MapTo());
        return listOfDomain;
    }

    public async Task Update(Domain.Sponsor model)
    {
        await context.Sponsors
            .Where(e => e.SponsorId == model.SponsorId)
            .ExecuteUpdateAsync(setter => 
                setter
                .SetProperty(e => e.SponsorName, model.SponsorName)
                .SetProperty(e => e.UpdatedAt, DateTime.UtcNow)
            );
    }
}
