using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.Application.UseCases.Auth.LoginUseCase;


namespace IPM.Application.IServices;

  public interface IAuthService
  {
      void Login(SignInRequest req);
      Task Register(RegisterRequest req);
  }
 
