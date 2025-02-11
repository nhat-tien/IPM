namespace IPM.Application.IRepositories;

public interface IParticipationRepository: IResourceRepository<Domain.Participation>
{
    Task DeleteByIdAsync(string userId, int projectId);
}
