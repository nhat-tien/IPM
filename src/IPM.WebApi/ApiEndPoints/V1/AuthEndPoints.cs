namespace IPM.WebApi.ApiEndPoints.V1;

using Microsoft.AspNetCore.Http.HttpResults;
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
            async Task<Results<Ok<SignInResponse>,UnauthorizedHttpResult>> (SignInRequest req, HttpContext httpContext, ILoginUseCase handler) =>
            {
                SignInResponse res = await handler.Handle(req);
                if (res.IsSuccess)
                {
                    SetTokenInsideCookie(res.RefreshToken!, httpContext);
                    return TypedResults.Ok(res);
                }
                else
                {
                    return TypedResults.Unauthorized();
                }
            }
        );
        endpoints
            .MapPost(
                "/register",
                async Task<Results<Ok<RegisterResponse>, BadRequest<RegisterResponse>>> (RegisterRequest req, IRegisterUseCase handler)  =>
                {
                    var res = await handler.Handle(req);
                    if (res.IsSuccess)
                    {
                        return TypedResults.Ok(res);
                    }
                    else
                    {
                        return TypedResults.BadRequest(res);
                    }
                }
            )
            .WithRequestValidation<RegisterRequest>();

        endpoints.MapPost(
            "/refresh",
            async Task<Results<Ok<RefreshTokenResponse>, BadRequest<RefreshTokenResponse>, BadRequest>> (HttpContext httpContext, IRefreshTokenUseCase handler) =>
            {
                httpContext.Request.Cookies.TryGetValue("RefreshToken", out var refreshToken);
                if (refreshToken is null)
                {
                    return TypedResults.BadRequest();
                }
                var res = await handler.Handle(new RefreshTokenRequest(refreshToken));
                if (res.IsSuccess)
                {
                    SetTokenInsideCookie(res.RefreshToken!, httpContext);
                    return TypedResults.Ok(res);
                }
                else
                {
                    return TypedResults.BadRequest(res);
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
                Path = "/api/v1/auth/refresh",
                SameSite = SameSiteMode.Strict,
            }
        );
    }
}
