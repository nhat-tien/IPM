namespace IPM.WebApi.ApiEndPoints.V1;

public static class MapEndPoints
{
  public static void MapEndPointsApi(this WebApplication app) 
  {
      RouteGroupBuilder routeGroup = app.MapGroup("/api/v1");

      AuthEndPoint.Map(routeGroup);
      ProjectEndPoint.Map(routeGroup);
  }
}
