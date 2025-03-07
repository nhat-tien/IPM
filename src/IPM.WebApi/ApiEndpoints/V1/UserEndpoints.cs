using IPM.Application.UseCases.User.GetAllUserUseCase;
using IPM.Application.UseCases.User.UploadAvatarUseCase;
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
                "/{userId}/avatar",
                async (
                    string userId,
                    IFormFile image,
                    IUploadAvatarUseCase handler
                ) =>
                {
                    if (userId is null)
                    {
                        return Results.BadRequest();
                    }

                    var fileTest = new FormFileProxy(image);
                    var contentType = fileTest.ContentType;

                    if(!contentType.Equals("image/png") && !contentType.Equals("image/jpeg"))
                    {
                        Console.Write(contentType);
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

