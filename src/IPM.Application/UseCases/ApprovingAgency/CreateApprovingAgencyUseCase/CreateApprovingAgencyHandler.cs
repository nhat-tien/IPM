
using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.ApprovingAgency.CreateApprovingAgencyUseCase;

public class CreateApprovingAgencyHandler(IApprovingAgencyRepository repo): ICreateApprovingAgencyUseCase
{
    public async Task Handle(CreateApprovingAgencyRequest req)
    {
        var domainEntity = new Domain.ApprovingAgency() {
           ApprovingAgencyName = req.ApprovingAgencyName
        };
        await repo.Create(domainEntity);
    }
}
