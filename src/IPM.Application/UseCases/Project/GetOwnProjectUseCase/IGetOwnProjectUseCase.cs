using IPM.Application.Queries;

namespace IPM.Application.UseCases.Project.GetOwnProjectUseCase;

public interface IGetOwnProjectUseCase
{
    Task<IEnumerable<Domain.Project>> Handle(string userId, CriteriaQuery query);
}
