namespace IPM.Application.UseCases.Project.CreateProjectUseCase;

public interface ICreateProjectUseCase
{
    Task Handle(CreateProjectRequest req);
}
