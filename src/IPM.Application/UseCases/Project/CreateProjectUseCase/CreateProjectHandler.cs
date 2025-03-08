using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Project.CreateProjectUseCase;

public class CreateProjectHandler(IProjectRepository projectRepo, IParticipationRepository partRepo): ICreateProjectUseCase
{
    public async Task<Domain.Project> Handle(CreateProjectRequest req, string userId)
    {
        var project = await projectRepo.AddAsync(req.MapTo());

        Domain.Participation participation = new Domain.Participation()
        {
            ProjectId = project.ProjectId,
            UserId = userId,
            Owner = true,
        };
        await partRepo.AddAsync(participation);
        return project;
    }
}
