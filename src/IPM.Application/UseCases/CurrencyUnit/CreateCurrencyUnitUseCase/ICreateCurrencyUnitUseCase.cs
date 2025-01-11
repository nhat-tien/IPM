namespace IPM.Application.UseCases.CurrencyUnit.CreateCurrencyUnitUseCase;

public interface ICreateCurrencyUnitUseCase
{
    Task Handle(CreateCurrencyUnitRequest req);
}
