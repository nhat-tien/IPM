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
        if(roles.Count < 1) 
        {
            return SignInResponse.Error("User have no role");
        }

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
            ExpiresOnUtc = DateTime.UtcNow.AddMinutes(5),
        };
        await refreshTokenRepo.Add(refreshToken);

        return SignInResponse.Ok("Success", token, refreshToken.Token);
    }
}

