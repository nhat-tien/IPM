namespace IPM.WebApi.ApiEndpoints.V1;

public static class MapEndpoints
{
  public static void MapEndpointsApi(this WebApplication app) 
  {
      var endpoints = app.MapGroup("/api/v1");

      AuthEndpoints.Map(endpoints);
      ProjectEndpoints.Map(endpoints);
      RoleEndpoints.Map(endpoints);
      ApprovingAgencyEndpoints.Map(endpoints);
      AffiliatedUnitEndpoints.Map(endpoints);
      CurrencyUnitEndpoints.Map(endpoints);
      AidTypeEndpoints.Map(endpoints);
      UserEndpoints.Map(endpoints);
      CategoryEndpoints.Map(endpoints);
      CounterpartyEndpoints.Map(endpoints);
      PositionEndpoints.Map(endpoints);
      SponsorEndpoints.Map(endpoints);
      FileTypeEndpoints.Map(endpoints);
      FileEndpoints.Map(endpoints);
  }
}
