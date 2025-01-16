namespace IPM.WebApi.ApiEndPoints.V1;

public static class MapEndPoints
{
  public static void MapEndPointsApi(this WebApplication app) 
  {
      var endpoints = app.MapGroup("/api/v1");

      AuthEndPoints.Map(endpoints);
      ProjectEndPoints.Map(endpoints);
      RoleEndPoints.Map(endpoints);
      ApprovingAgencyEndPoints.Map(endpoints);
      AffiliatedUnitEndPoints.Map(endpoints);
      CurrencyUnitEndPoints.Map(endpoints);
      AidTypeEndPoints.Map(endpoints);
      UserEndPoints.Map(endpoints);
      CatalogueEndPoints.Map(endpoints);
      CounterpartyEndPoints.Map(endpoints);
      PositionEndPoints.Map(endpoints);
      SponsorEndPoints.Map(endpoints);
  }
}
