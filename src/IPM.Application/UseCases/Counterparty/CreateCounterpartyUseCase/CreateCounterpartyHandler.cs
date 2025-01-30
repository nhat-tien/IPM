using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.Counterparty.CreateCounterpartyUseCase;

public class CreateCounterpartyHandler(ICounterpartyRepository repo): ICreateCounterpartyUseCase
{
    public async Task Handle(CreateCounterpartyRequest req)
    {
        Domain.Counterparty entity = new Domain.Counterparty() {
            CounterpartyName = req.CounterpartyName
        };
        await repo.AddAsync(entity);
    }
}
