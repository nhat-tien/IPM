using IPM.Application.IRepositories;
using IPM.Domain;
using IPM.Infrastructure.EntityFrameworkDataAccess.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace IPM.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class AuditLogRepository : GenericRepository<Domain.AuditLog, Entities.AuditLog>, IAuditLogRepository
{
    public AuditLogRepository(AppDBContext db) : base(db)
    {
    }

    public async Task<IEnumerable<AuditLog>> GetAllAsync(int projectId)
    {
        return await db.AuditLog
            .Where(e => e.ProjectId == projectId)
            .Select(e => e.MapTo())
            .ToListAsync();
    }

    public override int GetDomainId(Domain.AuditLog domain)
    {
        return domain.AuditLogId;
    }

    public override Entities.AuditLog MapFromDomain(Domain.AuditLog domain)
    {
        return Entities.AuditLog.MapFrom(domain);
    }

    public override Domain.AuditLog MapToDomain(Entities.AuditLog entity)
    {
        return entity.MapTo();
    }

    public override IQueryable<Entities.AuditLog> WhereId(int id)
    {
        return db.AuditLog.Where(e => e.AuditLogId == id);
    }
}
