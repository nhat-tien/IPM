using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.UpdateProjectUseCase;

public class UpdateProjectHandler(IProjectRepository repo, IAuditLogRepository auditLog) : IUpdateProjectUseCase
{
    public async Task Handle(int id, UpdateProjectRequest req) 
    { 
        Domain.Project domain = req.MapTo();
        domain.ProjectId = id;
        await repo.UpdateAsync(domain, req.SetValueProperties);

        await auditLog.AddAsync(new Domain.AuditLog() {
            Activity = "Update project"
            ProjectId = id,
            UserId = req.userId
        });
    }

    private GetActivityAndDesForAuditLog(List<string> setValueProperties) {
        if setValueProperties.Contains()
    }
}
