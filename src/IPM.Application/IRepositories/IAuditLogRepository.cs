using IPM.Domain;

namespace IPM.Application.IRepositories;

public interface IAuditLogRepository: IGenericRepository<AuditLog>
{
    Task<IEnumerable<Domain.AuditLog>> GetAllAsync(int projectId);
}
