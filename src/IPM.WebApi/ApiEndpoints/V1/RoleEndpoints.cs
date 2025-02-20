using IPM.Application.UseCases.Role;

namespace IPM.WebApi.ApiEndpoints.V1;

public class RoleEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/roles");

        endpoints
            .MapGet("/", (IGetAllRoleUseCase handler) => handler.Execute())
            .RequireAuthorization("AdminPermission");
    }
}
