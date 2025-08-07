namespace IPM.Application.IRepositories;

public interface IParticipationRepository: IGenericRepository<Domain.Participation>
{
    Task DeleteByIdAsync(string userId, int projectId);

    Task<IEnumerable<Domain.Participation>> GetByUserId(string userId);
}
