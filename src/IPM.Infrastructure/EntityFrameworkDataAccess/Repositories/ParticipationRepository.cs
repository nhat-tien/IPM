using System.Reflection;
using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class ParticipationRepository
    : GenericRepository<Domain.Participation, Participation>,
        IParticipationRepository
{
    public ParticipationRepository(AppDBContext ctx)
        : base(ctx) { }

    public override int GetDomainId(Domain.Participation domain)
    {
        throw new NotImplementedException();
    }

    public override Participation MapFromDomain(Domain.Participation domain)
    {
        return Participation.MapFrom(domain);
    }

    public override Domain.Participation MapToDomain(Participation entity)
    {
        return entity.MapTo();
    }

    public override IQueryable<Participation> WhereId(int id)
    {
        throw new NotImplementedException();
    }

    public override async Task UpdateAsync(Domain.Participation domain) 
    {
        var userId = domain.UserId;
        var projectId = domain.ProjectId;

        Participation? entity = await db
            .Participations.Where(e => e.UserId == userId)
            .Where(e => e.ProjectId == projectId)
            .FirstOrDefaultAsync();

        if(entity is null) return;

        db.Participations.Attach(entity);

        Type typeOfModel = domain.GetType();
        PropertyInfo[] properties = typeOfModel.GetProperties();

        foreach(PropertyInfo property in properties) 
        {
            if(property.GetValue(domain) is not null) 
            {
                db.Entry(entity).Property(property.Name).CurrentValue = property.GetValue(domain); 
            }
        }
        entity.UpdatedAt = DateTime.UtcNow;
        await db.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(string userId, int projectId)
    {
        await db
            .Participations.Where(e => e.UserId == userId)
            .Where(e => e.ProjectId == projectId)
            .ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Domain.Participation>> GetByUserId(string userId)
    {
        var participations = await db.Participations
            .Where(e => e.UserId == userId)
            .Where(e => e.Project != null)
            .Include(e => e.Project!.AffiliatedUnit)
            .Include(e => e.Project!.AidType)

            .ToListAsync();

        var participationsDomain = participations.Select(e => e.MapToWithProject());
        return participationsDomain;
    }
}
