using IPM.Application.IRepositories;
namespace IPM.Application.UseCases.Counterparty.UpdateCounterpartyUseCase;

public class UpdateCounterpartyHandler(ICounterpartyRepository repo) : IUpdateCounterpartyUseCase
{
    public async Task Handle(int id, UpdateCounterpartyRequest req)
    {
        Domain.Counterparty entity = new Domain.Counterparty()
        {
            CounterpartyId = id,
            CounterpartyName = req.CounterpartyName,
        };
        await repo.UpdateAsync(entity);
    }
}
