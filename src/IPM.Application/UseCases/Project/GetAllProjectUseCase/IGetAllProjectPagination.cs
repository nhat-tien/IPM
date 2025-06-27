using IPM.Application.Queries;
using IPM.Application.ResponseDto;

namespace IPM.Application.UseCases.Project.GetAllProjectUseCase;

public interface IGetAllProjectPagination
{
    Task<PaginationResponse<Domain.Project>> Handle(CriteriaQuery query);
}
