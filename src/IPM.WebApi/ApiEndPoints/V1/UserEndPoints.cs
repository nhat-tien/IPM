namespace IPM.WebApi.ApiEndPoints.V1;

public class UserEndPoints
{
  public static void Map(RouteGroupBuilder route) 
  {
    var endpoints = route.MapGroup("/users");

    endpoints.MapGet("/profile", () => "Project");
  }
}
 
