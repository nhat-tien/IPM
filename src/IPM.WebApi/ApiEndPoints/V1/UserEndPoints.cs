using IPM.Application.UseCases.User.GetAllUserUseCase;
namespace IPM.WebApi.ApiEndPoints.V1;

public class UserEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/users");

        endpoints.MapGet("/", async (IGetAllUserUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");
    }
}

