using IPM.Application.IRepositories;
namespace IPM.Application.UseCases.CurrencyUnit.CreateCurrencyUnitUseCase;

public class CreateCurrencyUnitHandler(ICurrencyUnitRepository repo): ICreateCurrencyUnitUseCase
{
    public async Task Handle(Domain.CurrencyUnit model)
    {
        await repo.Create(model);
    }
}
