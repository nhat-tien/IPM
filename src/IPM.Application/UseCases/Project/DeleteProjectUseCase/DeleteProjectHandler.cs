using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.DeleteProjectUseCase;

public class DeleteProjectHandler(IProjectRepository repo): IDeleteProjectUseCase
{
    public async Task Handle(int id)
    {
        await repo.DeleteSoftByIdAsync(id);
    }
}
