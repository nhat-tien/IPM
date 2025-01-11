using FluentValidation;
using IPM.Application.UseCases.AffiliatedUnit.UpdateAffiliatedUnitUseCase;

namespace IPM.WebApi.Validators.AffiliatedUnit;

public class AffiliatedUnitUpdateValidator : AbstractValidator<UpdateAffiliatedUnitRequest>
{
    public AffiliatedUnitUpdateValidator()
    {
        RuleFor(req => req.AffiliatedUnitName).NotEmpty();
    }
}
