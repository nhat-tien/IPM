using IPM.Application.UseCases.Sponsor.CreateSponsorUseCase;
using IPM.Application.UseCases.Sponsor.DeleteSponsorUseCase;
using IPM.Application.UseCases.Sponsor.GetAllSponsorUseCase;
using IPM.Application.UseCases.Sponsor.UpdateSponsorUseCase;
using IPM.WebApi.Filters;

namespace IPM.WebApi.ApiEndPoints.V1;

public class SponsorEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/catalogue");

        endpoints.MapGet("/", async (IGetAllSponsorUseCase handler) => await handler.Handle())
        .RequireAuthorization("UserPermission");

        endpoints.MapPost("/", async (CreateSponsorRequest req, ICreateSponsorUseCase handler) => {
                await handler.Handle(req);
        })
        .WithRequestValidation<CreateSponsorRequest>()
        .RequireAuthorization("UserPermission");

        endpoints.MapDelete("/{id}", async (int id, IDeleteSponsorUseCase handler) => {
                await handler.Handle(id);
        });
        endpoints.MapPatch("/{id}", async (int id, UpdateSponsorRequest req, IUpdateSponsorUseCase handler) => {
                await handler.Handle(id, req);
        }).WithRequestValidation<UpdateSponsorRequest>();
    }
}
