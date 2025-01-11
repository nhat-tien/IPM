using FluentValidation;
using IPM.Application.UseCases.AffiliatedUnit.CreateAffiliatedUnitUseCase;

namespace IPM.WebApi.Validators.AffiliatedUnit;

public class AffiliatedUnitCreateValidator : AbstractValidator<CreateAffiliatedUnitRequest>
{
    public AffiliatedUnitCreateValidator()
    {
        RuleFor(req => req.AffiliatedUnitName).NotEmpty();
    }
}
