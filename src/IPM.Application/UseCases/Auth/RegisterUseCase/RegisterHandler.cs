using IPM.Application.IServices;

namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public class RegisterHandler : IRegisterUseCase
{
    private IAuthService authService;

    public RegisterHandler(IAuthService authService)
    {
        this.authService = authService;
    }

    public async Task<RegisterResponse> Execute(RegisterRequest req)
    {
        var result =  await this.authService.Register(req);
        return new RegisterResponse(result.IsSuccess, result.Errors);
    }
}

public record RegisterResponse(bool IsSuccess, Dictionary<string, string[]>? Errors);
