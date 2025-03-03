using IPM.Application.UseCases.User.GetAllUserUseCase;
using IPM.Application.UseCases.User.UploadAvatarUseCase;
using IPM.WebApi.Helper;
using IPM.WebApi.Utils;
namespace IPM.WebApi.ApiEndpoints.V1;

public class UserEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/users");

        endpoints.MapGet("/", async (IGetAllUserUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints
            .MapPost(
                "/avatar",
                async (
                    HttpContext context,
                    IFormFile image,
                    IUploadAvatarUseCase handler
                ) =>
                {
                    var userId = GetUserIdFromHttpContext.Get(context);
                    if (userId is null)
                    {
                        return Results.BadRequest();
                    }
                    await handler.Handle(new FormFileProxy(image), userId);
                    return Results.Ok();
                }
            )
            //WARN: Disable antiforgery - this seem bad practice, I'll check this later
            .DisableAntiforgery()
            .RequireAuthorization("UserPermission");

    }
}

