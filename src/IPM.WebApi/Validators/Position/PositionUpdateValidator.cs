using FluentValidation;
using IPM.Application.UseCases.Position.UpdatePositionUseCase;

namespace IPM.WebApi.Validators.Position;

public class PositionUpdateValidator : AbstractValidator<UpdatePositionRequest>
{
    public PositionUpdateValidator()
    {
        RuleFor(r => r.PositionName).NotEmpty();
    }
}
