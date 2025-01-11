using IPM.Application.IRepositories;
namespace IPM.Application.UseCases.CurrencyUnit.DeleteCurrencyUnitUseCase;

public class DeleteCurrencyUnitHandler(ICurrencyUnitRepository repo): IDeleteCurrencyUnitUseCase
{
    public async Task Handle(int id)
    {
        await repo.Delete(id);
    }
}
