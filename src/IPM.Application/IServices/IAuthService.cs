using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;

namespace IPM.Application.IServices;

public interface IAuthService
{
    void Login(SignInRequest req);
    Task<AuthResultDto> Register(RegisterRequest req);
}

public record AuthResultDto(bool IsSuccess, Dictionary<string, string[]>? Errors);
