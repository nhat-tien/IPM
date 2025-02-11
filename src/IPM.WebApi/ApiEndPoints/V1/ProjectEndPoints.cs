using IPM.Application.UseCases.Project.AssignUserToProjectUseCase;
using IPM.Application.UseCases.Project.CreateProjectUseCase;
using IPM.Application.UseCases.Project.DeleteProjectUseCase;
using IPM.Application.UseCases.Project.GetAllProjectUseCase;
using IPM.Application.UseCases.Project.UpdateProjectUseCase;
using IPM.WebApi.Filters;

namespace IPM.WebApi.ApiEndPoints.V1;

public static class ProjectEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/projects");

        endpoints
            .MapGet("/", async (IGetAllProjectUseCase handler) => await handler.Handle())
            .RequireAuthorization("UserPermission");

        endpoints
            .MapPost(
                "/",
                async (CreateProjectRequest req, ICreateProjectUseCase handler) =>
                {
                    await handler.Handle(req);
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
                "/{id}",
                async (int id, IDeleteProjectUseCase handler) =>
                {
                    await handler.Handle(id);
                }
            )
            .RequireAuthorization("UserPermission");

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
