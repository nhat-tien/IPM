namespace IPM.Application.UseCases.CurrencyUnit.CreateCurrencyUnitUseCase;

public interface ICreateCurrencyUnitUseCase
{
    Task Handle(Domain.CurrencyUnit model);
}
