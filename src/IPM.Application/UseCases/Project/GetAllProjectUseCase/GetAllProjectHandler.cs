
using IPM.Application.IRepositories;
using IPM.Application.Queries.Project;

namespace IPM.Application.UseCases.Project.GetAllProjectUseCase;

public class GetAllProjectHandler(IProjectRepository repo): IGetAllProjectUseCase
{
    public async Task<IEnumerable<Domain.Project>> Handle(ProjectQuery query)
    {
        return await repo.GetAllAsync(query);
    }
}
