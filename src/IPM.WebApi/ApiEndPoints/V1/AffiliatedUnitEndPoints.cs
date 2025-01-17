using IPM.Application.UseCases.AffiliatedUnit.CreateAffiliatedUnitUseCase;
using IPM.Application.UseCases.AffiliatedUnit.DeleteAffiliatedUnitUseCase;
using IPM.Application.UseCases.AffiliatedUnit.GetAllAffiliatedUnitUseCase;
using IPM.Application.UseCases.AffiliatedUnit.UpdateAffiliatedUnitUseCase;

using IPM.WebApi.Filters;

namespace IPM.WebApi.ApiEndPoints.V1;

public class AffiliatedUnitEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/affiliatedUnit");

        endpoints.MapGet("/", async (IGetAllAffiliatedUnitUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints.MapPost("/", async (CreateAffiliatedUnitRequest req, ICreateAffiliatedUnitUseCase handler) => {
                await handler.Handle(req);
        })
        .WithRequestValidation<CreateAffiliatedUnitRequest>()
        .RequireAuthorization("UserPermission");

        endpoints.MapDelete("/{id}", async (int id, IDeleteAffiliatedUnitUseCase handler) => {
                await handler.Handle(id);
        })
        .RequireAuthorization("UserPermission");

        endpoints.MapPatch("/{id}", async (int id, UpdateAffiliatedUnitRequest req, IUpdateAffiliatedUnitUseCase handler) => {
                await handler.Handle(id, req);
        }).WithRequestValidation<UpdateAffiliatedUnitRequest>()
        .RequireAuthorization("UserPermission");
    }
}
