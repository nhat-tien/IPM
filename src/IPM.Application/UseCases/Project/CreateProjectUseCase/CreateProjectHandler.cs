using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.CreateProjectUseCase;

public class CreateProjectHandler(IProjectRepository projectRepo, IParticipationRepository partRepo): ICreateProjectUseCase
{
    public async Task<Domain.Project> Handle(CreateProjectRequest req, string userId)
    {
        Domain.Project project = await projectRepo.AddAsync(req.MapTo());

        Domain.Participation participation = new Domain.Participation()
        {
            ProjectId = project.ProjectId,
            UserId = userId,
            Role = "OWNER",
        };
        await partRepo.AddAsync(participation);

        return project;
    }
}
