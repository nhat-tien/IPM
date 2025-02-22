using IPM.Application.Queries;
using IPM.Application.UseCases.Project.AssignUserToProjectUseCase;
using IPM.Application.UseCases.Project.CreateProjectUseCase;
using IPM.Application.UseCases.Project.DeleteProjectUseCase;
using IPM.Application.UseCases.Project.GetAllProjectUseCase;
using IPM.Application.UseCases.Project.GetProjectUseCase;
using IPM.Application.UseCases.Project.UpdateProjectUseCase;
using IPM.WebApi.EndpointFilters;
using IPM.WebApi.ResponseDtos;

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
                    IGetAllProjectUseCase handler
                ) =>
                {
                   var query = new CriteriaQuery()
                   {
                       Include = include,
                       SortColumn = sortBy,
                       SortOrder = sortOrd,
                   };
                   return await handler.Handle(query);
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

                   var result = new OptionResult<Domain.Project>(await handler.Handle(id, query));

                   return result.GetResult();
                }
            )
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
