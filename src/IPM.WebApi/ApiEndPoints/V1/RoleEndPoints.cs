using IPM.Application.UseCases.Role;

namespace IPM.WebApi.ApiEndPoints.V1;

public class RoleEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/roles");

        endpoints
            .MapGet("/", (IGetAllRoleUseCase handler) => handler.Execute())
            .RequireAuthorization("AdminPermission");
    }
}
