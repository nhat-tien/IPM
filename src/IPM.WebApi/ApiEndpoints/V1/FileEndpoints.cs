using IPM.Application.UseCases.File.UploadFileUseCase;
using IPM.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;

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

        endpoints.MapGet("/project/{id}", (int id) => { });
    }
}
