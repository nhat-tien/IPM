using IPM.Application.IRepositories;
using IPM.Infrastructure.EntityFrameworkDataAccess.Entities;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class PositionRepository : GenericRepository<Domain.Position, Position>, IPositionRepository
{
    public PositionRepository(AppDBContext ctx) : base(ctx)
    {
    }

    public override int GetDomainId(Domain.Position domain)
    {
        return domain.PositionId;
    }

    public override IQueryable<Position> WhereId(int id)
    {
        return context.Positions.Where(e => e.PositionId == id);
    }

    public override Position MapFromDomain(Domain.Position domain)
    {
        return Position.MapFrom(domain);
    }

    public override Domain.Position MapToDomain(Position entity)
    {
        return entity.MapTo();
    }
}
