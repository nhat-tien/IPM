
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.AuditLog.GetAuditLogUseCase;

public class GetAuditLogHandler(IAuditLogRepository repo): IGetAuditLogUseCase
{
    public async Task<IEnumerable<Domain.AuditLog>> Handle(int projectId)
    {
        return await repo.GetAllAsync(projectId);
    }
}
