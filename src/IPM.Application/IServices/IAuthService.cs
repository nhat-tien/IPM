using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.Application.UseCases.Auth.RefreshTokenUseCase;

namespace IPM.Application.IServices;

public interface IAuthService
{
    Task<SignInResponse> Login(SignInRequest req);
    Task<RegisterResponse> Register(RegisterRequest req);
    Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest req);
}

