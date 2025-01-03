namespace IPM.WebApi.ApiEndPoints.V1;

using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RefreshTokenUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.WebApi.Filters;

public class AuthEndPoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/auth");

        endpoints.MapPost(
            "/login",
            async (SignInRequest req, HttpContext httpContext, ILoginUseCase handler) =>
            {
                var res = await handler.Handle(req);
                if (res.IsSuccess)
                {
                    SetTokenInsideCookie(res.RefreshToken!, httpContext);
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

        endpoints.MapPost(
            "/refresh-token",
            async (HttpContext httpContext, IRefreshTokenUseCase handler) =>
            {
                httpContext.Request.Cookies.TryGetValue("RefreshToken", out var refreshToken);
                if (refreshToken is null)
                {
                    return Results.BadRequest();
                }
                var res = await handler.Handle(new RefreshTokenRequest(refreshToken));
                if (res.IsSuccess)
                {
                    SetTokenInsideCookie(res.RefreshToken!, httpContext);
                    return Results.Ok(res);
                }
                else
                {
                    return Results.BadRequest(res);
                }
            }
        );
    }

    public static void SetTokenInsideCookie(string refreshToken, HttpContext context)
    {
        context.Response.Cookies.Append(
            "RefreshToken",
            refreshToken,
            new CookieOptions
            {
                Expires = DateTime.Now.AddDays(2),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                Domain = "localhost",
                Path = "/api/v1/auth/refresh-token",
                SameSite = SameSiteMode.Strict,
            }
        );
    }
}
