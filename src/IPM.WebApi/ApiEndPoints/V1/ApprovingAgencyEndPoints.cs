using IPM.Application.UseCases.ApprovingAgency.CreateApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.DeleteApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.GetAllApprovingAgencyUseCase;
using IPM.Application.UseCases.ApprovingAgency.UpdateApprovingAgencyUseCase;
using IPM.WebApi.Filters;

namespace IPM.WebApi.ApiEndPoints.V1;

public class ApprovingAgencyEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/approvingAgency");

        endpoints.MapGet("/", async (IGetAllApprovingAgencyUseCase handler) => await handler.Handle());

        endpoints.MapPost("/", async (CreateApprovingAgencyRequest req, ICreateApprovingAgencyUseCase handler) => {
                await handler.Handle(req);
        }).WithRequestValidation<CreateApprovingAgencyRequest>();

        endpoints.MapDelete("/{id}", async (int id, IDeleteApprovingAgencyUseCase handler) => {
                await handler.Handle(id);
        });
        endpoints.MapPatch("/{id}", async (int id, UpdateApprovingAgencyRequest req, IUpdateApprovingAgencyUseCase handler) => {
                await handler.Handle(id, req);

        }).WithRequestValidation<UpdateApprovingAgencyRequest>();
    }
}
