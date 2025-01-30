using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.ApprovingAgency.GetAllApprovingAgencyUseCase;

public class GetAllApprovingAgencyHandler(IApprovingAgencyRepository repo): IGetAllApprovingAgencyUseCase
{
    public async Task<IEnumerable<Domain.ApprovingAgency>> Handle()
    {
        return await repo.GetAllAsync();
    }
}
