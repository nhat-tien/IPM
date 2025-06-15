using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.UpdateProjectUseCase;

public class UpdateProjectHandler(IProjectRepository repo) : IUpdateProjectUseCase
{
    public async Task Handle(int id, UpdateProjectRequest req) 
    { 
        Domain.Project domain = req.MapTo();
        domain.ProjectId = id;
        await repo.UpdateAsync(domain, req.SetValueProperties);
    }
}
