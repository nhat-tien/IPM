using IPM.Application.IServices;

namespace IPM.Application.UseCases.Auth.LoginUseCase;

public class LoginHandler: ILoginUseCase
{    
    private IAuthService authService;

    public LoginHandler(IAuthService authService)
    {
        this.authService = authService;
    }


    public SignInResponse Execute(SignInRequest req)
    {
        // authService.Login(req);
        return new SignInResponse();
    }
}
