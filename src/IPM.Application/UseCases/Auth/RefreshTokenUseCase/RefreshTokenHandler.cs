using FluentValidation;
using IPM.Application.IRepositories;
using IPM.Application.IServices;
using IPM.Domain;

namespace IPM.Application.UseCases.Auth.RefreshTokenUseCase;

  public class RefreshTokenHandler(IAuthService authService, IUserRepository userRepo, IRefreshTokenRepository refreshTokenRepo): IRefreshTokenUseCase
  {

    public async Task<RefreshTokenResponse> Handle(RefreshTokenRequest req)
    {
        RefreshToken? refreshToken = await refreshTokenRepo.FindByTokenIncludeUser(req.RefreshToken);

        if(refreshToken is null || refreshToken.ExpiresOnUtc < DateTime.UtcNow || refreshToken.User is null)
        {
            return RefreshTokenResponse.Error("The refresh token is expired");
        }
        var roles = await userRepo.GetRoles(refreshToken.User);
        string accessToken = authService.CreateAccessToken(refreshToken.User, roles[0]);
        string newRefreshToken = authService.GenerateRefreshToken();
        await refreshTokenRepo.Update(refreshToken.Token, newRefreshToken);
        return RefreshTokenResponse.Ok("Refresh success", accessToken, newRefreshToken);
    }
  }


public class RefreshTokenResponse {
    public bool IsSuccess {get; private set;}
    public string? Message {get; private set;}
    public string? AccessToken {get; private set;}
    public string? RefreshToken {get; private set;}

    public static RefreshTokenResponse Ok(string message, string accessToken, string refreshToken)
    {
        return new RefreshTokenResponse() {
            IsSuccess = true,
            Message = message,
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public static RefreshTokenResponse Error(string errors)
    {
        return new RefreshTokenResponse() {
            IsSuccess = false,
            Message = errors,
            AccessToken = null,
            RefreshToken = null 
        };
    }
};

  public record RefreshTokenRequest (
      string RefreshToken
  );

public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(req => req.RefreshToken).NotEmpty();
    }
}
 
