using FluentValidation;
using IPM.Application.UseCases.Auth.RegisterUseCase;

namespace IPM.WebApi.Validators.Auth;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(req => req.Email).NotEmpty().EmailAddress();
        RuleFor(req => req.FirstName).NotEmpty();
        RuleFor(req => req.LastName).NotEmpty();
        RuleFor(req => req.Password).NotEmpty().Length(6,20);
        RuleFor(req => req.RoleId).NotEmpty().Must(roleId => roleId == "2" || roleId == "3");
        // RuleFor(req => req.AffiliatedUnitId).NotEmpty();
        // RuleFor(req => req.PositionId).NotEmpty();
    }
}
