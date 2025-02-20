using IPM.Application.UseCases.User.GetAllUserUseCase;
namespace IPM.WebApi.ApiEndpoints.V1;

public class UserEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/users");

        endpoints.MapGet("/", async (IGetAllUserUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");
    }
}

