using IPM.Application.Queries;

namespace IPM.Application.UseCases.Project.GetAllProjectUseCase;

public interface IGetAllProjectUseCase
{
    Task<IEnumerable<Domain.Project>> Handle(CriteriaQuery query);
}
