namespace IPM.WebApi.ApiEndPoints;

public static class MapEndPoints
{
  public static void AddEndPointsApi(this WebApplication app) 
  {
      AuthEndPoint.Map(app);
      ProjectEndPoint.Map(app);
  }
}
