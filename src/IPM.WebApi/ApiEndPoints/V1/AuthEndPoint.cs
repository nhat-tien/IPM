namespace IPM.WebApi.ApiEndPoints.V1;

using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;

public static class AuthEndPoint 
{
  public static void Map(RouteGroupBuilder endpoints) 
  {
    endpoints.MapPost("/login", (SignInRequest req, ILoginUseCase handler) => handler.Execute(req));
    endpoints.MapPost("/register", (RegisterRequest req, IRegisterUseCase handler) => handler.Execute(req));
  }

}

