using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.CreateProjectUseCase;

public class CreateProjectHandler(IProjectRepository repo): ICreateProjectUseCase
{
    public async Task<Domain.Project> Handle(CreateProjectRequest req)
    {
        return await repo.AddAsync(req.MapTo());
    }
}
