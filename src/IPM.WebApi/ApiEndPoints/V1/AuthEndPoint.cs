namespace IPM.WebApi.ApiEndPoints.V1;

using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.WebApi.Filters;

public static class AuthEndPoint
{
    public static void Map(RouteGroupBuilder endpoints)
    {
        endpoints.MapPost(
            "/login",
            async (SignInRequest req, ILoginUseCase handler) =>
            {
                var res = await handler.Handle(req);
                if (res.IsSuccess)
                {
                    return Results.Ok(res);
                }
                else
                {
                    return Results.BadRequest(res);
                }
            }
        );
        endpoints
            .MapPost(
                "/register",
                async (RegisterRequest req, IRegisterUseCase handler) =>
                {
                    var res = await handler.Handle(req);
                    if (res.IsSuccess)
                    {
                        return Results.Ok(res);
                    }
                    else
                    {
                        return Results.BadRequest(res);
                    }
                }
            )
            .WithRequestValidation<RegisterRequest>();
    }
}
