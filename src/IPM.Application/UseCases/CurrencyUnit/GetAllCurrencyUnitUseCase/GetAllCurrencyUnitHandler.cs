using IPM.Application.IRepositories;

namespace IPM.Application.UseCases.CurrencyUnit.GetAllCurrencyUnitUseCase;

public class GetAllCurrencyUnitHandler(ICurrencyUnitRepository repo) : IGetAllCurrencyUnitUseCase
{
    public async Task<IEnumerable<Domain.CurrencyUnit>> Handle()
    {
        return await repo.GetAllAsync();
    }
}
