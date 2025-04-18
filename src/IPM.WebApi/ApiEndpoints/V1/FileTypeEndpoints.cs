using IPM.Application.UseCases.FileType.CreateFileTypeUseCase;
using IPM.Application.UseCases.FileType.DeleteFileTypeUseCase;
using IPM.Application.UseCases.FileType.GetAllFileTypeUseCase;
using IPM.Application.UseCases.FileType.UpdateFileTypeUseCase;
using IPM.WebApi.EndpointFilters;

namespace IPM.WebApi.ApiEndpoints.V1;

public class FileTypeEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/fileTypes");

        endpoints.MapGet("/", async (IGetAllFileTypeUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints.MapPost("/", async (CreateFileTypeRequest req, ICreateFileTypeUseCase handler) => {
                await handler.Handle(req);
        }).WithRequestValidation<CreateFileTypeRequest>()
        .RequireAuthorization("UserPermission");

        endpoints.MapDelete("/{id}", async (int id, IDeleteFileTypeUseCase handler) => {
                await handler.Handle(id);
        })
        .RequireAuthorization("UserPermission");

        endpoints.MapPatch("/{id}", async (int id, UpdateFileTypeRequest req, IUpdateFileTypeUseCase handler) => {
                await handler.Handle(id, req);

        }).WithRequestValidation<UpdateFileTypeRequest>()
        .RequireAuthorization("UserPermission");
    }
}
