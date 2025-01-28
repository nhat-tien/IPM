namespace IPM.Application.UseCases.Project.UpdateProjectUseCase;

public interface IUpdateProjectUseCase
{
    Task Handle(int id, UpdateProjectRequest req);
}
