using FluentValidation;
using IPM.Application.UseCases.AidType.CreateAidTypeUseCase;

namespace IPM.WebApi.Validators.AidType;

public class AidTypeCreateValidator : AbstractValidator<CreateAidTypeRequest>
{
    public AidTypeCreateValidator()
    {
        RuleFor(req => req.AidTypeName).NotEmpty();
    }
}
