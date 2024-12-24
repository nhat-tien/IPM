using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;

namespace IPM.Application.IServices;

  public interface IAuthService
  {
      void Login(LoginRequest req);
      Task Register(RegisterRequest req);
  }
 
