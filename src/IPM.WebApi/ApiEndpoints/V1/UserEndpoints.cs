using IPM.Application.Queries;
using IPM.Application.UseCases.User.GetCurrentUserUseCase;
using IPM.Application.UseCases.User.GetAllUserUseCase;
using IPM.Application.UseCases.User.UpdateUserInfoUseCase;
using IPM.Application.UseCases.User.UploadAvatarUseCase;
using IPM.Application.UseCases.User.VerifyUserUseCase;
using IPM.WebApi.Helper;
using IPM.WebApi.Utils;

namespace IPM.WebApi.ApiEndpoints.V1;

public class UserEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/users");

        endpoints
            .MapGet("/", async (
                        string? include, 
                        string? sortBy,
                        string? sortOrd,
                        string? filter,
                        int? page,
                        int? pageSize,
                        bool? pageMetadata,
                        IGetAllUserUseCase handler
                    ) => {
                   var query = new CriteriaQuery()
                   {
                       Filter = filter,
                       Include = include,
                       SortColumn = sortBy,
                       SortOrder = sortOrd,
                       Page = page,
                       PageSize = pageSize,
                       PageMetadata = pageMetadata
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

        endpoints.MapPatch(
            "/{userId}/verified",
            async (string userId, IVerifyUserUseCase handler) => {
                await handler.Handle(userId);
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
                    string? sortBy,
                    string? sortOrd,
                    string? filter,
                    int? page,
                    int? pageSize,
                    HttpContext context,
                    IGetCurrentUserUseCase handler
                ) =>
                {
                   var query = new CriteriaQuery()
                   {
                       Include = include,
                       Filter = filter,
                       SortColumn = sortBy,
                       SortOrder = sortOrd,
                       Page = page,
                       PageSize = pageSize
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

    }
}
