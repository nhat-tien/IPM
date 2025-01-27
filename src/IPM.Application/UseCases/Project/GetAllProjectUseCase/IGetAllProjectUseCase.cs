namespace IPM.Application.UseCases.Project.GetAllProjectUseCase;

public interface IGetAllProjectUseCase
{
    Task<IEnumerable<Domain.Project>> Handle();
}
