using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Counterparty.DeleteCounterpartyUseCase;

public class DeleteCounterpartyHandler(ICounterpartyRepository repo): IDeleteCounterpartyUseCase
{
    public async Task Handle(int id)
    {
        await repo.DeleteByIdAsync(id);
    }
}
