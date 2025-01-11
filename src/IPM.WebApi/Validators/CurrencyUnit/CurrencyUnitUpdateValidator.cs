using FluentValidation;
using IPM.Application.UseCases.CurrencyUnit.UpdateCurrencyUnitUseCase;

namespace IPM.WebApi.Validators.CurrencyUnit;

public class CurrencyUnitUpdateValidator : AbstractValidator<UpdateCurrencyUnitRequest>
{
    public CurrencyUnitUpdateValidator()
    {
        RuleFor(req => req.CurrencyUnitName).NotEmpty();
    }
}
