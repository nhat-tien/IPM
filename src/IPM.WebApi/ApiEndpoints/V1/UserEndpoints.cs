using IPM.Application.Queries;
using IPM.Application.UseCases.User.GetCurrentUserUseCase;
using IPM.WebApi.Helper;
using IPM.Application.UseCases.User.GetAllUserUseCase;
using IPM.Application.UseCases.User.UpdateUserInfoUseCase;
using IPM.Application.UseCases.User.UploadAvatarUseCase;
using IPM.WebApi.Utils;
using System.Security.Claims;
using IPM.Application.ResponseDto;

namespace IPM.WebApi.ApiEndpoints.V1;

public class UserEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/users");

        endpoints
            .MapGet("/", async (string? include, IGetAllUserUseCase handler) => {
                   var query = new CriteriaQuery()
                   {
                       Include = include,
                   };
                    return await handler.Handle(query);
            })
            .RequireAuthorization("UserPermission");

        endpoints.MapPatch(
            "/{userId}",
            async (string userId, UpdateUserInfoRequest req, IUpdateUserInfoUseCase handler) => {
                await handler.Handle(userId, req);
            }
        );

        endpoints
            .MapPost(
                "/{userId}/avatar",
                async (string userId, IFormFile image, IUploadAvatarUseCase handler) =>
                {
                    if (userId is null)
                    {
                        return Results.BadRequest();
                    }

                    var fileTest = new FormFileProxy(image);
                    var contentType = fileTest.ContentType;

                    if (!contentType.Equals("image/png") && !contentType.Equals("image/jpeg"))
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

        endpoints
            .MapGet(
                "/profile",
                async (
                    string? include,
                    HttpContext context,
                    IGetCurrentUserUseCase handler
                ) =>
                {
                   var query = new CriteriaQuery()
                   {
                       Include = include,
                   };

                    var userId = GetUserIdFromHttpContext.Get(context);
                    if (userId is null)
                    {
                        return Results.BadRequest();
                    }
                    Domain.User? user = await handler.Handle(userId, query);
                    if (user is null)
                    {
                        return Results.BadRequest();
                    }
                    return Results.Ok(user);
                }
            )
            .RequireAuthorization("UserPermission");

        endpoints.MapGet("/info",(
                    HttpContext context
                    ) => {
            if (context.User is ClaimsPrincipal principal)
            {
                var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                var userEmail = principal.FindFirst(ClaimTypes.Email)?.Value ?? "";
                var firstName = principal.FindFirst("firstName")?.Value ?? "";
                var lastName = principal.FindFirst("lastName")?.Value ?? "";
                var role = principal.FindFirst(ClaimTypes.Role)?.Value ?? "";
                return Results.Ok(new UserInfo(userId, userEmail, firstName,lastName, role));
            } else {
                return Results.BadRequest();
            }
        })
        .RequireAuthorization("UserPermission");
    }
}
