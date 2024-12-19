namespace IPM.WebApi.ApiEndPoints;

public static class ProjectEndPoint
{
  public static void Map(WebApplication app) 
  {
    app.MapGet("/api/project", () => "Project");
  }
}
