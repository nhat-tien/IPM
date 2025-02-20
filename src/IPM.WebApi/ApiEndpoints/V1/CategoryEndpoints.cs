using IPM.Application.UseCases.Category.CreateCategoryUseCase;
using IPM.Application.UseCases.Category.DeleteCategoryUseCase;
using IPM.Application.UseCases.Category.GetAllCategoryUseCase;
using IPM.Application.UseCases.Category.UpdateCategoryUseCase;
using IPM.WebApi.EndpointFilters;

namespace IPM.WebApi.ApiEndpoints.V1;

public class CategoryEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/categories");

        endpoints.MapGet("/", async (IGetAllCategoryUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints.MapPost("/", async (CreateCategoryRequest req, ICreateCategoryUseCase handler) => {
                await handler.Handle(req);
        })
        .WithRequestValidation<CreateCategoryRequest>()
        .RequireAuthorization("UserPermission");

        endpoints.MapDelete("/{id}", async (int id, IDeleteCategoryUseCase handler) => {
                await handler.Handle(id);
        })
        .RequireAuthorization("UserPermission");

        endpoints.MapPatch("/{id}", async (int id, UpdateCategoryRequest req, IUpdateCategoryUseCase handler) => {
                await handler.Handle(id, req);
        }).WithRequestValidation<UpdateCategoryRequest>()
        .RequireAuthorization("UserPermission");
    }
}
