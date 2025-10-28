namespace IPM.Application.UseCases.AuditLog.CreateAuditLogUseCase;

public interface ICreateAuditLogUseCase
{
    Task Handle(CreateAuditLogRequest req);
}
