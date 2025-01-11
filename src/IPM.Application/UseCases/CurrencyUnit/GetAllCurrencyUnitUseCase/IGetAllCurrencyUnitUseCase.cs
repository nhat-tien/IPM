namespace IPM.Application.UseCases.CurrencyUnit.GetAllCurrencyUnitUseCase;

public interface IGetAllCurrencyUnitUseCase
{
    Task<IEnumerable<Domain.CurrencyUnit>> Handle();
}
