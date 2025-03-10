using IPM.Application.UseCases.Counterparty.CreateCounterpartyUseCase;
using IPM.Application.UseCases.Counterparty.DeleteCounterpartyUseCase;
using IPM.Application.UseCases.Counterparty.GetAllCounterpartyUseCase;
using IPM.Application.UseCases.Counterparty.UpdateCounterpartyUseCase;
using IPM.WebApi.EndpointFilters;

namespace IPM.WebApi.ApiEndpoints.V1;

public class CounterpartyEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/counterparties");

        endpoints.MapGet("/", async (IGetAllCounterpartyUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints.MapPost("/", async (CreateCounterpartyRequest req, ICreateCounterpartyUseCase handler) => {
                await handler.Handle(req);
        })
        .WithRequestValidation<CreateCounterpartyRequest>()
        .RequireAuthorization("UserPermission");

        endpoints.MapDelete("/{id}", async (int id, IDeleteCounterpartyUseCase handler) => {
                await handler.Handle(id);
        })
        .RequireAuthorization("UserPermission");

        endpoints.MapPatch("/{id}", async (int id, UpdateCounterpartyRequest req, IUpdateCounterpartyUseCase handler) => {
                await handler.Handle(id, req);
        }).WithRequestValidation<UpdateCounterpartyRequest>()
        .RequireAuthorization("UserPermission");
    }
}
