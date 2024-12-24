using IPM.Application.IServices;

namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public class RegisterHandler : IRegisterUseCase
{
    private IAuthService authService;

    public RegisterHandler(IAuthService authService)
    {
        this.authService = authService;
    }

    public RegisterResponse Execute(RegisterRequest req)
    {
        // this.authService.Register(req);
        return new RegisterResponse();
    }
}
