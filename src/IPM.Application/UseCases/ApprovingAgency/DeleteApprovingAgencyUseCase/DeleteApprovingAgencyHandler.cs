using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.ApprovingAgency.DeleteApprovingAgencyUseCase;

public class DeleteApprovingAgencyHandler(IApprovingAgencyRepository repo): IDeleteApprovingAgencyUseCase
{
    public async Task Handle(int id)
    {
        await repo.DeleteByIdAsync(id);
    }
}
