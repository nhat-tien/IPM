using IPM.Application.IServices;
using FluentValidation;

namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public class RegisterHandler : IRegisterUseCase
{
    private IAuthService authService;

    public RegisterHandler(IAuthService authService)
    {
        this.authService = authService;
    }

    public async Task<RegisterResponse> Handle(RegisterRequest req)
    {
        return await this.authService.Register(req);
    }
}

public class RegisterResponse {
    public bool IsSuccess {get; private set;}
    public string? Message {get; private set;}
    public Dictionary<string, string[]>? Errors {get; private set;}

    public static RegisterResponse Ok(string message)
    {
        return new RegisterResponse() {
            IsSuccess = true,
            Errors = null,
            Message = message
        };
    }

    public static RegisterResponse Error(Dictionary<string, string[]> errors)
    {
        return new RegisterResponse() {
            IsSuccess = false,
            Errors = errors,
            Message = null
        };
    }
};

public record JwtToken(
        string AccessToken
);

public record RegisterRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password,
    string RoleId,
    int AffiliatedUnitId,
    int PositionId
);

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(req => req.Email).NotEmpty().EmailAddress();
        RuleFor(req => req.FirstName).NotEmpty();
        RuleFor(req => req.LastName).NotEmpty();
        RuleFor(req => req.Password).NotEmpty().Length(6,20);
        RuleFor(req => req.RoleId).NotEmpty();
        RuleFor(req => req.AffiliatedUnitId).NotEmpty();
        RuleFor(req => req.PositionId).NotEmpty();
    }
}
