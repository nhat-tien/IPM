namespace IPM.WebApi.ApiEndPoints.V1;

public static class ProjectEndPoint
{
  public static void Map(RouteGroupBuilder route) 
  {
    var routeGroup = route.MapGroup("/project");
    routeGroup.MapGet("/", () => "Project");
    routeGroup.MapGet("/{id}", (int id) => "Project" + id);
  }
}
