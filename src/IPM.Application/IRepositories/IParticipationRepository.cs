namespace IPM.Application.IRepositories;

public interface IParticipationRepository: IGenericRepository<Domain.Participation>
{
    Task DeleteByIdAsync(string userId, int projectId);
}
