namespace IPM.Application.UseCases.Project.AssignUserToProjectUseCase;

public interface IAssignUserToProjectUseCase
{
    Task Handle(AssignUserToProjectRequest req);
}
