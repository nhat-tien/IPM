namespace IPM.Application.UseCases.Project.RemoveUserInProjectUseCase;

public interface IRemoveUserInProjectUseCase
{
    Task Handle(RemoveUserInProjectRequest req);
}
