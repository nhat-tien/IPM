using FluentValidation;
using IPM.Application.UseCases.Position.CreatePositionUseCase;

namespace IPM.WebApi.Validators.Position;

public class PositionCreateValidator : AbstractValidator<CreatePositionRequest>
{
    public PositionCreateValidator()
    {
        RuleFor(r => r.PositionName).NotEmpty();
    }
}
