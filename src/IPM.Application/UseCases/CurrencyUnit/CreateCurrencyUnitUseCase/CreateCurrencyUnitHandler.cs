using IPM.Application.IRepositories;
namespace IPM.Application.UseCases.CurrencyUnit.CreateCurrencyUnitUseCase;

public class CreateCurrencyUnitHandler(ICurrencyUnitRepository repo): ICreateCurrencyUnitUseCase
{
    public async Task Handle(CreateCurrencyUnitRequest req)
    {
        Domain.CurrencyUnit model = new Domain.CurrencyUnit() {
            CurrencyUnitName = req.CurrencyUnitName
        };
        await repo.Create(model);
    }
}
