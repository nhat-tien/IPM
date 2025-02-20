using IPM.Application.UseCases.Sponsor.CreateSponsorUseCase;
using IPM.Application.UseCases.Sponsor.DeleteSponsorUseCase;
using IPM.Application.UseCases.Sponsor.GetAllSponsorUseCase;
using IPM.Application.UseCases.Sponsor.UpdateSponsorUseCase;
using IPM.WebApi.EndpointFilters;

namespace IPM.WebApi.ApiEndpoints.V1;

public class SponsorEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/sponsors");

        endpoints
            .MapGet("/", async (IGetAllSponsorUseCase handler) => await handler.Handle())
            .RequireAuthorization("UserPermission");

        endpoints
            .MapPost(
                "/",
                async (CreateSponsorRequest req, ICreateSponsorUseCase handler) =>
                {
                    await handler.Handle(req);
                }
            )
            .WithRequestValidation<CreateSponsorRequest>()
            .RequireAuthorization("UserPermission");

        endpoints
            .MapDelete(
                "/{id}",
                async (int id, IDeleteSponsorUseCase handler) =>
                {
                    await handler.Handle(id);
                }
            )
            .RequireAuthorization("UserPermission");

        endpoints
            .MapPatch(
                "/{id}",
                async (int id, UpdateSponsorRequest req, IUpdateSponsorUseCase handler) =>
                {
                    await handler.Handle(id, req);
                }
            )
            .WithRequestValidation<UpdateSponsorRequest>()
            .RequireAuthorization("UserPermission");
    }
}
