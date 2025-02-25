using IPM.Application.Queries;

namespace IPM.Application.UseCases.Project.GetProjectUseCase;

public interface IGetProjectUseCase
{
    Task<Domain.Project?> Handle(int id, CriteriaQuery query);
}
