namespace IPM.Application.UseCases.CurrencyUnit.DeleteCurrencyUnitUseCase;

public interface IDeleteCurrencyUnitUseCase
{
    Task Handle(int id);
}
