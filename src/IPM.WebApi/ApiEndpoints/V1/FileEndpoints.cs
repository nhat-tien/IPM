using IPM.Application.UseCases.File.UploadFileUseCase;
using IPM.Application.UseCases.File.GetFileInProject;
using IPM.Application.UseCases.File.GetUrlDownloadFileUseCase;
using IPM.Application.UseCases.File.UpdateFileTypeOfFileUseCase;
using IPM.WebApi.Utils;
using Microsoft.AspNetCore.Mvc;
using IPM.Application.UseCases.File.DeleteFileUseCase;
using IPM.Application.Queries;

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
                    [FromForm] string userId,
                    IUploadFileUseCase handler
                ) =>
                {
                    await handler.Handle(new FormFileProxy(file), fileTypeId, projectId, userId);
                }
            )
            //WARN: Disable antiforgery - this seem bad practice, I'll check this later
            .DisableAntiforgery()
            .RequireAuthorization("UserPermission");

        endpoints.MapGet("/project/{projectId}", async (
                    int projectId,
                    string? include,
                    string? sortBy,
                    string? sortOrd,
                    string? filter,
                    int? page,
                    int? pageSize,
                    bool? pageMetadata,
                    IGetFileInProject handler) =>
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

            return await handler.Handle(projectId, query);
        }).RequireAuthorization("UserPermission");


        endpoints.MapGet("/{fileId}/url", async (int fileId, IGetUrlDownloadFileUseCase handler) =>
        {
            return await handler.Handle(fileId);
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

        endpoints.MapPatch(
                "/{fileId}",
                async (
                    int fileId,
                    UpdateFileTypeOfFileRequest req,
                    IUpdateFileTypeOfFileUseCase handler
                    ) =>
                {
                    await handler.Handle(fileId, req);
                }
        ).RequireAuthorization("UserPermission");
    }
}
