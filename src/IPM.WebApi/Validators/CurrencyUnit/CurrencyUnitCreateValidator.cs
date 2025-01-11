using FluentValidation;
using IPM.Application.UseCases.CurrencyUnit.CreateCurrencyUnitUseCase;

namespace IPM.WebApi.Validators.CurrencyUnit;

public class CurrencyUnitCreateValidator : AbstractValidator<CreateCurrencyUnitRequest>
{
    public CurrencyUnitCreateValidator()
    {
        RuleFor(req => req.CurrencyUnitName).NotEmpty();
    }
}
