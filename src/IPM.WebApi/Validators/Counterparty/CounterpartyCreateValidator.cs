using FluentValidation;
using IPM.Application.UseCases.Counterparty.CreateCounterpartyUseCase;

namespace IPM.WebApi.Validators.Counterparty;

public class CounterpartyCreateValidator : AbstractValidator<CreateCounterpartyRequest>
{
    public CounterpartyCreateValidator()
    {
        RuleFor(req => req.CounterpartyName).NotEmpty();
    }
}
