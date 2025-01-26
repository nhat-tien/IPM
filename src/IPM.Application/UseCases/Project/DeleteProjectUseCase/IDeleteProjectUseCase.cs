namespace IPM.Application.UseCases.Project.DeleteProjectUseCase;

public interface IDeleteProjectUseCase
{
    Task Handle(int id);
}
