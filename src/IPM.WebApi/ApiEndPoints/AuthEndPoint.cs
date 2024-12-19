namespace IPM.WebApi.ApiEndPoints;

public static class AuthEndPoint 
{
  public static void Map(WebApplication app) 
  {
    app.MapGet("/api/auth", () => "Auth");
  }
}
