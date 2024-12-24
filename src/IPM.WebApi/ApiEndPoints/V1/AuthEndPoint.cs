namespace IPM.WebApi.ApiEndPoints.V1;

using IPM.Application.UseCases.Auth.LoginUseCase;

public static class AuthEndPoint 
{
  public static void Map(RouteGroupBuilder route) 
  {
    route.MapPost("/login", (LoginRequest req, ILoginUseCase handler) => handler.Execute(req));
    route.MapPost("/register", () => new { message = "Hello" });
  }

}

