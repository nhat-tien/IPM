using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class AidTypeRepository : GenericRepository<Domain.AidType, AidType>, IAidTypeRepository
{
    public AidTypeRepository(AppDBContext ctx) : base(ctx)
    {
    }

    public override int GetDomainId(Domain.AidType domain)
    {
        return domain.AidTypeId;
    }

    public override IQueryable<AidType> WhereId(int id)
    {
        return db.AidTypes.Where(e => e.AidTypeId == id);
    }

    public override AidType MapFromDomain(Domain.AidType domain)
    {
        return AidType.MapFrom(domain);
    }

    public override Domain.AidType MapToDomain(AidType entity)
    {
        return entity.MapTo();
    }
}
