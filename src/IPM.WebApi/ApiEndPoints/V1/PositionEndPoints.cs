using IPM.Application.UseCases.Position.CreatePositionUseCase;
using IPM.Application.UseCases.Position.DeletePositionUseCase;
using IPM.Application.UseCases.Position.GetAllPositionUseCase;
using IPM.Application.UseCases.Position.UpdatePositionUseCase;
using IPM.WebApi.Filters;

namespace IPM.WebApi.ApiEndPoints.V1;

public class PositionEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/position");

        endpoints.MapGet("/", async (IGetAllPositionUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints.MapPost("/", async (CreatePositionRequest req, ICreatePositionUseCase handler) => {
                await handler.Handle(req);
        })
        .WithRequestValidation<CreatePositionRequest>()
        .RequireAuthorization("UserPermission");

        endpoints.MapDelete("/{id}", async (int id, IDeletePositionUseCase handler) => {
                await handler.Handle(id);
        })
        .RequireAuthorization("UserPermission");

        endpoints.MapPatch("/{id}", async (int id, UpdatePositionRequest req, IUpdatePositionUseCase handler) => {
                await handler.Handle(id, req);
        }).WithRequestValidation<UpdatePositionRequest>()
        .RequireAuthorization("UserPermission");

    }
}
