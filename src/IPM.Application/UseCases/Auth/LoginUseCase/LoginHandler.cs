using System.Text.Json.Serialization;
using FluentValidation;
using IPM.Application.IRepositories;
using IPM.Application.IServices;
using IPM.Domain;

namespace IPM.Application.UseCases.Auth.LoginUseCase;

public class LoginHandler(
    IUserRepository userRepo,
    IAuthService authService,
    IRefreshTokenRepository refreshTokenRepo
) : ILoginUseCase
{
    public async Task<SignInResponse> Handle(SignInRequest req)
    {
        Domain.User? user = await userRepo.FindByName(req.Email);
        if (user is null)
        {
            return SignInResponse.Error("User was not found");
        }
        var roles = await userRepo.GetRoles(user);

        bool verify = await userRepo.CheckPassword(user, req.Password);
        if (!verify)
        {
            return SignInResponse.Error("Password incorrect");
        }
        string token = authService.CreateAccessToken(user, roles[0]);

        var refreshToken = new RefreshToken
        {
            Id = Guid.NewGuid(),
            UserId = user.UserId!,
            Token = authService.GenerateRefreshToken(),
            ExpiresOnUtc = DateTime.UtcNow.AddDays(1),
        };
        await refreshTokenRepo.Add(refreshToken);

        return SignInResponse.Ok("Success", token, refreshToken.Token);
    }
}

public class SignInResponse
{
    public bool IsSuccess { get; private set; }

    public string? Message { get; private set; }

    public string? AccessToken { get; private set; }

    [JsonIgnore]
    public string? RefreshToken { get; private set; }

    public static SignInResponse Ok(string message, string accessToken, string refreshToken)
    {
        return new SignInResponse()
        {
            IsSuccess = true,
            Message = message,
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };
    }

    public static SignInResponse Error(string errors)
    {
        return new SignInResponse()
        {
            IsSuccess = false,
            Message = errors,
            AccessToken = null,
            RefreshToken = null,
        };
    }
};

public record SignInRequest(string Email, string Password);

public class SignInRequestValidator : AbstractValidator<SignInRequest>
{
    public SignInRequestValidator()
    {
        RuleFor(req => req.Email).NotEmpty().EmailAddress();
        RuleFor(req => req.Password).NotEmpty();
    }
}
