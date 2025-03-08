using IPM.Application.UseCases.File.UploadFileUseCase;
using IPM.Application.UseCases.File.GetFileInProject;
using IPM.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;
using IPM.Application.UseCases.File.DeleteFileUseCase;

namespace IPM.WebApi.ApiEndpoints.V1;

public class FileEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/file");

        endpoints
            .MapPost(
                "/",
                async (
                    IFormFile file,
                    [FromForm] string fileTypeId,
                    [FromForm] string projectId,
                    IUploadFileUseCase handler
                ) =>
                {
                    await handler.Handle(new FormFileProxy(file), fileTypeId, projectId);
                }
            )
            //WARN: Disable antiforgery - this seem bad practice, I'll check this later
            .DisableAntiforgery()
            .RequireAuthorization("UserPermission");

        endpoints.MapGet("/project/{id}", async (int id, IGetFileInProject handler) => {
            return await handler.Handle(id);
        }).RequireAuthorization("UserPermission");

        endpoints
            .MapDelete(
            "/{fileId}",
            async (
                int fileId,
                IDeleteFileUseCase handler
            ) => 
            {
               await handler.Handle(fileId);
            }
        ).RequireAuthorization("UserPermission");

    }
}
