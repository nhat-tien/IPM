using FluentValidation;
using IPM.Application.UseCases.ApprovingAgency.CreateApprovingAgencyUseCase;

namespace IPM.WebApi.Validators.ApprovingAgency;

public class ApprovingAgencyCreateValidator : AbstractValidator<CreateApprovingAgencyRequest>
{
    public ApprovingAgencyCreateValidator()
    {
        RuleFor(req => req.ApprovingAgencyName).NotEmpty();
    }
}
