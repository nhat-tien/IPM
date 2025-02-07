using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class CurrencyUnitRepository : GenericRepository<Domain.CurrencyUnit, CurrencyUnit>, ICurrencyUnitRepository
{
    public CurrencyUnitRepository(AppDBContext ctx) : base(ctx)
    {
    }

    public override int GetDomainId(Domain.CurrencyUnit domain)
    {
        return domain.CurrencyUnitId;
    }

    public override IQueryable<CurrencyUnit> WhereId(int id)
    {
        return db.CurrencyUnits.Where(e => e.CurrencyUnitId == id);
    }

    public override CurrencyUnit MapFromDomain(Domain.CurrencyUnit domain)
    {
        return CurrencyUnit.MapFrom(domain);
    }

    public override Domain.CurrencyUnit MapToDomain(CurrencyUnit entity)
    {
        return entity.MapTo();
    }
}
