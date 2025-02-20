using IPM.Application.UseCases.ApprovingAgency.CreateApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.DeleteApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.GetAllApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.UpdateApprovingAgencyUseCase;
using IPM.WebApi.EndpointFilters;

namespace IPM.WebApi.ApiEndpoints.V1;

public class ApprovingAgencyEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/approvingAgencies");

        endpoints.MapGet("/", async (IGetAllApprovingAgencyUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints.MapPost("/", async (CreateApprovingAgencyRequest req, ICreateApprovingAgencyUseCase handler) => {
                await handler.Handle(req);
        }).WithRequestValidation<CreateApprovingAgencyRequest>()
        .RequireAuthorization("UserPermission");

        endpoints.MapDelete("/{id}", async (int id, IDeleteApprovingAgencyUseCase handler) => {
                await handler.Handle(id);
        })
        .RequireAuthorization("UserPermission");

        endpoints.MapPatch("/{id}", async (int id, UpdateApprovingAgencyRequest req, IUpdateApprovingAgencyUseCase handler) => {
                await handler.Handle(id, req);

        }).WithRequestValidation<UpdateApprovingAgencyRequest>()
        .RequireAuthorization("UserPermission");
    }
}
