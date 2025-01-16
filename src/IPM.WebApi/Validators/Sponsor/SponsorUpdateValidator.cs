using FluentValidation;
using IPM.Application.UseCases.Sponsor.UpdateSponsorUseCase;

namespace IPM.WebApi.Validators.Sponsor;

public class SponsorUpdateValidator : AbstractValidator<UpdateSponsorRequest>
{
    public SponsorUpdateValidator()
    {
        RuleFor(r => r.SponsorName).NotEmpty();
    }
}
