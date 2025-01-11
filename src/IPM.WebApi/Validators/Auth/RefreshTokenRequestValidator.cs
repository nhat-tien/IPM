using FluentValidation;
using IPM.Application.UseCases.Auth.RefreshTokenUseCase;

namespace IPM.WebApi.Validators.Auth;

public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(req => req.RefreshToken).NotEmpty();
    }
}
