using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;

namespace IPM.Application.IServices;

public interface IAuthService
{
    Task<SignInResponse> Login(SignInRequest req);
    Task<RegisterResponse> Register(RegisterRequest req);
}

