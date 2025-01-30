using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.AidType.DeleteAidTypeUseCase;

public class DeleteAidTypeHandler(IAidTypeRepository repo) : IDeleteAidTypeUseCase
{
    public async Task Handle(int id)
    {
        await repo.DeleteByIdAsync(id);
    }
}
