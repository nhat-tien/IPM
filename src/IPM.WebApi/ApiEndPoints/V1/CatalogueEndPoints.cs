using IPM.Application.UseCases.Catalogue.CreateCatalogueUseCase;
using IPM.Application.UseCases.Catalogue.DeleteCatalogueUseCase;
using IPM.Application.UseCases.Catalogue.GetAllCatalogueUseCase;
using IPM.Application.UseCases.Catalogue.UpdateCatalogueUseCase;
using IPM.WebApi.Filters;

namespace IPM.WebApi.ApiEndPoints.V1;

public class CatalogueEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/catalogue");

        endpoints.MapGet("/", async (IGetAllCatalogueUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints.MapPost("/", async (CreateCatalogueRequest req, ICreateCatalogueUseCase handler) => {
                await handler.Handle(req);
        })
        .WithRequestValidation<CreateCatalogueRequest>()
        .RequireAuthorization("UserPermission");

        endpoints.MapDelete("/{id}", async (int id, IDeleteCatalogueUseCase handler) => {
                await handler.Handle(id);
        });
        endpoints.MapPatch("/{id}", async (int id, UpdateCatalogueRequest req, IUpdateCatalogueUseCase handler) => {
                await handler.Handle(id, req);
        }).WithRequestValidation<UpdateCatalogueRequest>();
    }
}
