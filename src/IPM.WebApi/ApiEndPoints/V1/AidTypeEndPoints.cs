using IPM.Application.UseCases.AidType.CreateAidTypeUseCase;
using IPM.Application.UseCases.AidType.DeleteAidTypeUseCase;
using IPM.Application.UseCases.AidType.GetAllAidTypeUseCase;
using IPM.Application.UseCases.AidType.UpdateAidTypeUseCase;

using IPM.WebApi.Filters;

namespace IPM.WebApi.ApiEndPoints.V1;

public class AidTypeEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/aidType");

        endpoints.MapGet("/", async (IGetAllAidTypeUseCase handler) => await handler.Handle());

        endpoints.MapPost("/", async (CreateAidTypeRequest req, ICreateAidTypeUseCase handler) => {
                await handler.Handle(req);
        });
        endpoints.MapDelete("/{id}", async (int id, IDeleteAidTypeUseCase handler) => {
                await handler.Handle(id);
        });
        endpoints.MapPatch("/{id}", async (int id, UpdateAidTypeRequest req, IUpdateAidTypeUseCase handler) => {
                await handler.Handle(id, req);
        });
    }
}
