using FluentValidation;
using IPM.Application.UseCases.Counterparty.UpdateCounterpartyUseCase;

namespace IPM.WebApi.Validators.Counterparty;

public class CounterpartyUpdateValidator : AbstractValidator<UpdateCounterpartyRequest>
{
    public CounterpartyUpdateValidator()
    {
        RuleFor(req => req.CounterpartyName).NotEmpty();
    }
}
