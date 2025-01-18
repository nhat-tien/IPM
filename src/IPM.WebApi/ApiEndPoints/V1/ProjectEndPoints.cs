namespace IPM.WebApi.ApiEndPoints.V1;

public static class ProjectEndPoints
{
  public static void Map(RouteGroupBuilder route) 
  {
    var endpoints = route.MapGroup("/projects");

    endpoints.MapGet("/", () => "Project");
    endpoints.MapGet("/{id}", (int id) => "Project" + id);
  }
}
