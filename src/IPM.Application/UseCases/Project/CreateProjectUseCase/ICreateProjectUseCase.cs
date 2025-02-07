namespace IPM.Application.UseCases.Project.CreateProjectUseCase;

public interface ICreateProjectUseCase
{
    Task<Domain.Project> Handle(CreateProjectRequest req);
}
