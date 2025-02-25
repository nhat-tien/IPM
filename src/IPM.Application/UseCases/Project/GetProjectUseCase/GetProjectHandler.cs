using IPM.Application.IRepositories;
using IPM.Application.Queries;

namespace IPM.Application.UseCases.Project.GetProjectUseCase;

public class GetProjectHandler(IProjectRepository repo): IGetProjectUseCase
{
    public async Task<Domain.Project?> Handle(int id, CriteriaQuery query)
    {
        return await repo.FindByIdAsync(id, query);
    }
}
