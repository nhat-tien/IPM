using IPM.Application.Queries;
using IPM.Application.UseCases.Project.AssignUserToProjectUseCase;
using IPM.Application.UseCases.Project.CreateProjectUseCase;
using IPM.Application.UseCases.Project.DeleteProjectUseCase;
using IPM.Application.UseCases.Project.GetAllProjectUseCase;
using IPM.Application.UseCases.Project.GetProjectUseCase;
using IPM.Application.UseCases.Project.UpdateProjectUseCase;
using IPM.Application.UseCases.Project.RemoveUserInProjectUseCase;
using IPM.WebApi.EndpointFilters;
using Microsoft.AspNetCore.Mvc;
using IPM.WebApi.Helper;

namespace IPM.WebApi.ApiEndpoints.V1;

public static class ProjectEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/projects");

        endpoints
            .MapGet(
                "/",
                async (
                    string? include,
                    string? sortBy,
                    string? sortOrd,
                    string? filter,
                    int? page,
                    int? pageSize,
                    bool? pageMetadata,
                    IGetAllProjectUseCase handler,
                    IGetAllProjectPagination paginationHandler
                ) =>
                {
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
                   if(page is not null && pageSize is not null)
                   {
                       return Results.Ok(await paginationHandler.Handle(query));
                   } else {
                       return Results.Ok(await handler.Handle(query));
                   }
                }
            )
            .RequireAuthorization("UserPermission");


        endpoints
            .MapGet(
                "/{id}",
                async (
                    int id,
                    string? include,
                    string? sortBy,
                    string? sortOrd,
                    IGetProjectUseCase handler
                ) =>
                {
                   var query = new CriteriaQuery()
                   {
                       Include = include,
                       SortColumn = sortBy,
                       SortOrder = sortOrd,
                   };

                   var result = await handler.Handle(id, query);

                   if(result is not null) {
                      return Results.Ok(result);
                   } else {
                       return Results.NotFound();
                   }
                }
            )
            .RequireAuthorization("UserPermission");

        endpoints
            .MapPost(
                "/",
                async (CreateProjectRequest req, HttpContext ctx, ICreateProjectUseCase handler) =>
                {
                    var userId = GetUserIdFromHttpContext.Get(ctx);
                    if(userId is null) {
                        return Results.BadRequest();
                    }
                    await handler.Handle(req, userId);
                    return Results.Ok();
                }
            )
            .WithRequestValidation<CreateProjectRequest>()
            .RequireAuthorization("UserPermission");

        endpoints
            .MapPost(
                "/assignment",
                async (AssignUserToProjectRequest req, IAssignUserToProjectUseCase handler) =>
                {
                    await handler.Handle(req);
                }
            )
            .RequireAuthorization("UserPermission");

        endpoints
            .MapDelete(
                "/assignment",
                async ([FromBody] RemoveUserInProjectRequest req, IRemoveUserInProjectUseCase handler) =>
                {
                    await handler.Handle(req);
                }
            )
            .RequireAuthorization("UserPermission");

        endpoints
            .MapDelete(
                "/{id}",
                async (int id, IDeleteProjectUseCase handler) =>
                {
                    await handler.Handle(id);
                }
            )
            .RequireAuthorization("AdminPermission");

        endpoints
            .MapPatch(
                "/{id}",
                async (int id, UpdateProjectRequest req, IUpdateProjectUseCase handler) =>
                {
                    await handler.Handle(id, req);
                }
            )
            .WithRequestValidation<UpdateProjectRequest>()
            .RequireAuthorization("UserPermission");
    }
}
