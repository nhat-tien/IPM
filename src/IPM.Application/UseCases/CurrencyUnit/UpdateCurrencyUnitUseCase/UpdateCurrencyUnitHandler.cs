using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.CurrencyUnit.UpdateCurrencyUnitUseCase;

public class UpdateCurrencyUnitHandler(ICurrencyUnitRepository repo): IUpdateCurrencyUnitUseCase
{
    public async Task Handle(int id, UpdateCurrencyUnitRequest req)
    {
        Domain.CurrencyUnit model = new Domain.CurrencyUnit() {
            CurrencyUnitId = id,
            CurrencyUnitName = req.CurrencyUnitName
        };
        await repo.Update(id, model);
    }
}
