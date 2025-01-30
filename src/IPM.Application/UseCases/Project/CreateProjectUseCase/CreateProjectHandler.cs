using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.CreateProjectUseCase;

public class CreateProjectHandler(IProjectRepository repo): ICreateProjectUseCase
{
    public async Task Handle(CreateProjectRequest req)
    {
        await repo.AddAsync(req.MapTo());
    }
}
