using IPM.Application.IRepositories;
using IPM.Application.Queries;
using IPM.Application.ResponseDto;

namespace IPM.Application.UseCases.Project.GetAllProjectUseCase;

public class GetAllProjectPagination(IProjectRepository repo): IGetAllProjectPagination
{
    public async Task<PaginationResponse<Domain.Project>> Handle(CriteriaQuery query)
    {
        return await repo.GetAllWithPaginationAsync(query);
    }
}
