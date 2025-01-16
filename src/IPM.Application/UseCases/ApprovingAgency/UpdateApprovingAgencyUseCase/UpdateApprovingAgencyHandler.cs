using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.ApprovingAgency.UpdateApprovingAgencyUseCase;

public class UpdateApprovingAgencyHandler(IApprovingAgencyRepository repo): IUpdateApprovingAgencyUseCase
{
    public async Task Handle(int id, UpdateApprovingAgencyRequest req)
    {
        var model = new Domain.ApprovingAgency() {
            ApprovingAgencyId = id,
            ApprovingAgencyName = req.ApprovingAgencyName
        };
        await repo.Update(model);
    }
}
