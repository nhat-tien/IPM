using FluentValidation;
using IPM.Application.UseCases.ApprovingAgency.UpdateApprovingAgencyUseCase;

namespace IPM.WebApi.Validators.ApprovingAgency;

public class ApprovingAgencyUpdateValidator : AbstractValidator<UpdateApprovingAgencyRequest>
{
    public ApprovingAgencyUpdateValidator()
    {
        RuleFor(req => req.ApprovingAgencyName).NotEmpty();
    }
}
