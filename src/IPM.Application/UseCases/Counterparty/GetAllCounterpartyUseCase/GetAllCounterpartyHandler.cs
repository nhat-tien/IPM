using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Counterparty.GetAllCounterpartyUseCase;

public class GetAllCounterpartyHandler(ICounterpartyRepository repo): IGetAllCounterpartyUseCase
{
    public async Task<IEnumerable<Domain.Counterparty>> Handle()
    {
        return await repo.GetAllAsync();
    }
}
