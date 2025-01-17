using IPM.Application.UseCases.CurrencyUnit.CreateCurrencyUnitUseCase;
using IPM.Application.UseCases.CurrencyUnit.DeleteCurrencyUnitUseCase;
using IPM.Application.UseCases.CurrencyUnit.GetAllCurrencyUnitUseCase;
using IPM.Application.UseCases.CurrencyUnit.UpdateCurrencyUnitUseCase;
using IPM.WebApi.Filters;

namespace IPM.WebApi.ApiEndPoints.V1;

public class CurrencyUnitEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/currencyUnit");

        endpoints.MapGet("/", async (IGetAllCurrencyUnitUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints.MapPost("/", async (CreateCurrencyUnitRequest req, ICreateCurrencyUnitUseCase handler) => {
                await handler.Handle(req);
        }).WithRequestValidation<CreateCurrencyUnitRequest>()
        .RequireAuthorization("UserPermission");

        endpoints.MapDelete("/{id}", async (int id, IDeleteCurrencyUnitUseCase handler) => {
                await handler.Handle(id);
        })
        .RequireAuthorization("UserPermission");

        endpoints.MapPatch("/{id}", async (int id, UpdateCurrencyUnitRequest req, IUpdateCurrencyUnitUseCase handler) => {
                await handler.Handle(id, req);

        }).WithRequestValidation<UpdateCurrencyUnitRequest>()
        .RequireAuthorization("UserPermission");
    }
}
