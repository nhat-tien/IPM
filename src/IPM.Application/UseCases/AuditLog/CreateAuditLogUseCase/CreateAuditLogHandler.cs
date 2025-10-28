using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.AuditLog.CreateAuditLogUseCase;

public class CreateAuditLogHandler(IAuditLogRepository repo) : ICreateAuditLogUseCase
{
    public async Task Handle(CreateAuditLogRequest req)
    {
        Domain.AuditLog model = new Domain.AuditLog() {
            Activity = req.activity,
            Description = req.description,
            UserId = req.userId
        };
        await repo.AddAsync(model);
    }
}
