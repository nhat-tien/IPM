namespace IPM.WebApi.ApiEndPoints.V1;

public static class MapEndPoints
{
  public static void MapEndPointsApi(this WebApplication app) 
  {
      var endpoints = app.MapGroup("/api/v1");

      AuthEndPoint.Map(endpoints);
      ProjectEndPoint.Map(endpoints);
      RoleEndPoints.Map(endpoints);
  }
}
