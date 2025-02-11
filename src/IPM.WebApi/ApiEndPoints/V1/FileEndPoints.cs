using IPM.Application.UseCases.File.UploadFileUseCase;
using IPM.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.ApiEndPoints.V1;

public class FileEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        //WARN: Disable antiforgery - this seem bad practice, I'll check this later
        var endpoints = route.MapGroup("/file").DisableAntiforgery();

        endpoints.MapPost(
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
        .RequireAuthorization("UserPermission");
    }
}
