using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class ApprovingAgencyRepository : GenericRepository<Domain.ApprovingAgency, ApprovingAgency>, IApprovingAgencyRepository
{
    public ApprovingAgencyRepository(AppDBContext ctx) : base(ctx)
    {
    }

    public override int GetDomainId(Domain.ApprovingAgency domain)
    {
        return domain.ApprovingAgencyId;
    }

    public override IQueryable<ApprovingAgency> WhereId(int id)
    {
        return db.ApprovingAgencies.Where(e => e.ApprovingAgencyId == id);
    }

    public override ApprovingAgency MapFromDomain(Domain.ApprovingAgency domain)
    {
        return ApprovingAgency.MapFrom(domain);
    }

    public override Domain.ApprovingAgency MapToDomain(ApprovingAgency entity)
    {
        return entity.MapTo();
    }
}
