using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class AffiliatedUnitRepository
: GenericRepository<Domain.AffiliatedUnit, AffiliatedUnit>, IAffiliatedUnitRepository
{
    public AffiliatedUnitRepository(AppDBContext ctx) : base(ctx)
    {
    }
     
    public override IQueryable<AffiliatedUnit> WhereId(int id)
    {
        return db.AffiliatedUnits.Where(e => e.AffiliatedUnitId == id);
    }

    public override int GetDomainId(Domain.AffiliatedUnit domain)
    {
        return domain.AffiliatedUnitId;
    }

    public override AffiliatedUnit MapFromDomain(Domain.AffiliatedUnit domain)
    {
        return AffiliatedUnit.MapFrom(domain);
    }

    public override Domain.AffiliatedUnit MapToDomain(AffiliatedUnit entity)
    {
        return entity.MapTo();
    }

}
