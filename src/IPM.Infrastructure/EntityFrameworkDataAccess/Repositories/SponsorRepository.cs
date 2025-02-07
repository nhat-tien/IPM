using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class SponsorRepository : GenericRepository<Domain.Sponsor, Sponsor>, ISponsorRepository
{
    public SponsorRepository(AppDBContext ctx) : base(ctx)
    {
    }

    public override int GetDomainId(Domain.Sponsor domain)
    {
        return domain.SponsorId;
    }

    public override IQueryable<Sponsor> WhereId(int id)
    {
        return db.Sponsors.Where(e => e.SponsorId == id);
    }

    public override Sponsor MapFromDomain(Domain.Sponsor domain)
    {
        return Sponsor.MapFrom(domain);
    }

    public override Domain.Sponsor MapToDomain(Sponsor entity)
    {
        return entity.MapTo();
    }
}
