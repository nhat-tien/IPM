using FluentValidation;
using IPM.Application.UseCases.Auth.LoginUseCase;

namespace IPM.WebApi.Validators.Auth;

public class SignInRequestValidator: AbstractValidator<SignInRequest>
{
    public SignInRequestValidator()
    {
        RuleFor(req => req.Email).NotEmpty().EmailAddress();
        RuleFor(req => req.Password).NotEmpty();
    }
}
