using IPM.Application.UseCases.AidType.CreateAidTypeUseCase;
using IPM.Application.UseCases.AidType.DeleteAidTypeUseCase;
using IPM.Application.UseCases.AidType.GetAllAidTypeUseCase;
using IPM.Application.UseCases.AidType.UpdateAidTypeUseCase;
using IPM.WebApi.EndpointFilters;

namespace IPM.WebApi.ApiEndpoints.V1;

public class AidTypeEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/aidTypes");

        endpoints.MapGet("/", async (IGetAllAidTypeUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints.MapPost("/", async (CreateAidTypeRequest req, ICreateAidTypeUseCase handler) => {
                await handler.Handle(req);
        })
        .WithRequestValidation<CreateAidTypeRequest>()
        .RequireAuthorization("UserPermission");

        endpoints.MapDelete("/{id}", async (int id, IDeleteAidTypeUseCase handler) => {
                await handler.Handle(id);
        })
        .RequireAuthorization("UserPermission");

        endpoints.MapPatch("/{id}", async (int id, UpdateAidTypeRequest req, IUpdateAidTypeUseCase handler) => {
                await handler.Handle(id, req);
        })
        .WithRequestValidation<UpdateAidTypeRequest>()
        .RequireAuthorization("UserPermission");
    }
}
