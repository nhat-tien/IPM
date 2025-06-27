using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.AssignUserToProjectUseCase;

public class AssignUserToProjectHandler(IParticipationRepository repo) : IAssignUserToProjectUseCase
{
    public async Task Handle(AssignUserToProjectRequest req)
    {
        foreach (var assignment in req.Assignments)
        {
            Domain.Participation domain = new Domain.Participation()
            {
                ProjectId = assignment.ProjectId,
                UserId = assignment.UserId,
                Role = assignment.Role,
            };
            await repo.AddAsync(domain);
        }
    }
}
