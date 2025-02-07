using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class CounterpartyRepository
    : GenericRepository<Domain.Counterparty, Counterparty>,
        ICounterpartyRepository
{
    public CounterpartyRepository(AppDBContext ctx)
        : base(ctx) { }

    public override int GetDomainId(Domain.Counterparty domain)
    {
        return domain.CounterpartyId;
    }

    public override IQueryable<Counterparty> WhereId(int id)
    {
        return db.Counterparties.Where(e => e.CounterpartyId == id);
    }

    public override Counterparty MapFromDomain(Domain.Counterparty domain)
    {
        return Counterparty.MapFrom(domain);
    }

    public override Domain.Counterparty MapToDomain(Counterparty entity)
    {
        return entity.MapTo();
    }
}
