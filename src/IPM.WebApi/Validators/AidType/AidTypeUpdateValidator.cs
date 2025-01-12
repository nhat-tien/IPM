using FluentValidation;
using IPM.Application.UseCases.AidType.UpdateAidTypeUseCase;

namespace IPM.WebApi.Validators.AidType;

public class AidTypeUpdateValidator : AbstractValidator<UpdateAidTypeRequest>
{
    public AidTypeUpdateValidator()
    {
        RuleFor(req => req.AidTypeName).NotEmpty();
    }
}
