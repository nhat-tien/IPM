
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.GetAllProjectUseCase;

public class GetAllProjectHandler(IProjectRepository repo): IGetAllProjectUseCase
{
    public async Task<IEnumerable<Domain.Project>> Handle()
    {
        return await repo.GetAll();
    }
}
