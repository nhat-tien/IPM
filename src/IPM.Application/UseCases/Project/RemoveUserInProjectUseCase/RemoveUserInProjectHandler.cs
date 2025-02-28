
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.RemoveUserInProjectUseCase;

public class RemoveUserInProjectHandler(IParticipationRepository repo): IRemoveUserInProjectUseCase
{
    public async Task Handle(RemoveUserInProjectRequest req)
    {
        foreach (var assignment in req.Assignments)
        {
            await repo.DeleteByIdAsync(assignment.UserId, assignment.ProjectId);
        }
    }
}
