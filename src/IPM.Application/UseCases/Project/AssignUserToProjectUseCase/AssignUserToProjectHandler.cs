
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.AssignUserToProjectUseCase;

public class AssignUserToProjectHandler(IParticipationRepository repo): IAssignUserToProjectUseCase
{
    public async Task Handle(AssignUserToProjectRequest req)
    {
        Domain.Participation domain = new Domain.Participation() {
            ProjectId = req.ProjectId,
            UsersId = req.UserId,
            Owner = req.Owner
        };
        await repo.AddAsync(domain);
    }
}
