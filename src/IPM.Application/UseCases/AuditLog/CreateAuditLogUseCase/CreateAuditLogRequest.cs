namespace IPM.Application.UseCases.AuditLog.CreateAuditLogUseCase;

public record CreateAuditLogRequest(string description, string activity, string userId);
