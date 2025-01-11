namespace IPM.Application.UseCases.CurrencyUnit.UpdateCurrencyUnitUseCase;

public interface IUpdateCurrencyUnitUseCase
{
    Task Handle(int id, UpdateCurrencyUnitRequest req);
}
