using FluentValidation;
using IPM.Application.UseCases.Sponsor.CreateSponsorUseCase;

namespace IPM.WebApi.Validators.Sponsor;

public class SponsorCreateValidator : AbstractValidator<CreateSponsorRequest>
{
    public SponsorCreateValidator()
    {
        RuleFor(r => r.SponsorName).NotEmpty();
    }
}
