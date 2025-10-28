namespace IPM.Application.UseCases.AuditLog.GetAuditLogUseCase;

public interface IGetAuditLogUseCase
{
    Task<IEnumerable<Domain.AuditLog>> Handle(int projectId);
}
