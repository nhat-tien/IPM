using IPM.Application.IRepositories;
using IPM.Application.Queries;

namespace IPM.Application.UseCases.Project.GetOwnProjectUseCase;

public class GetOwnProjectHandler(IParticipationRepository participationRepository): IGetOwnProjectUseCase
{
    public async Task<IEnumerable<Domain.Project>> Handle(string userId, CriteriaQuery query)
    {
         var participations = await participationRepository.GetByUserId(userId);

         return participations
             .Select(e => e.Project)
             .Where(e => e != null)
             .Cast<Domain.Project>();
    }
}
