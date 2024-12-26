using IPM.Application.IServices;
using FluentValidation;

namespace IPM.Application.UseCases.Auth.LoginUseCase;

public class LoginHandler: ILoginUseCase
{    
    private IAuthService authService;

    public LoginHandler(IAuthService authService)
    {
        this.authService = authService;
    }

    public async Task<SignInResponse> Handle(SignInRequest req)
    {
        return await this.authService.Login(req);
    }
}

public class SignInResponse {
    public bool IsSuccess {get; private set;}
    public string? Message {get; private set;}
    public string? AccessToken {get; private set;}
    public string? RefreshToken {get; private set;}

    public static SignInResponse Ok(string message, string accessToken, string refreshToken)
    {
        return new SignInResponse() {
            IsSuccess = true,
            Message = message,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public static SignInResponse Error(string errors)
    {
        return new SignInResponse() {
            IsSuccess = false,
            Message = errors,
            AccessToken = null,
            RefreshToken = null 
        };
    }
};

  public record SignInRequest (
      string Email,
      string Password
  );

public class SignInRequestValidator : AbstractValidator<SignInRequest>
{
    public SignInRequestValidator()
    {
        RuleFor(req => req.Email).NotEmpty().EmailAddress();
        RuleFor(req => req.Password).NotEmpty();
    }
}
