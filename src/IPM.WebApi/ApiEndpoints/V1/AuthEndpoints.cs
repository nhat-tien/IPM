namespace IPM.WebApi.ApiEndpoints.V1;

using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.ResponseDto;
using IPM.Application.UseCases.Auth.LogoutUseCase;
using IPM.Application.UseCases.Auth.RefreshTokenUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.WebApi.EndpointFilters;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;

public class AuthEndpoints
{
    public static void Map(RouteGroupBuilder route)
    {
        var endpoints = route.MapGroup("/auth");

        endpoints
            .MapPost(
                "/login",
                async Task<Results<Ok<SignInResponse>, UnauthorizedHttpResult>> (
                    SignInRequest req,
                    HttpContext httpContext,
                    ILoginUseCase handler
                ) =>
                {
                    SignInResponse res = await handler.Handle(req);
                    if (res.IsSuccess)
                    {
                        SetTokenInsideCookie(res.AccessToken!, res.RefreshToken!, httpContext);
                        return TypedResults.Ok(res);
                    }
                    else
                    {
                        return TypedResults.Unauthorized();
                    }
                }
            )
            .WithRequestValidation<SignInRequest>();

        endpoints
            .MapPost(
                "/register",
                async Task<Results<Ok<RegisterResponse>, BadRequest<RegisterResponse>>> (
                    RegisterRequest req,
                    IRegisterUseCase handler
                ) =>
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
            async Task<
                Results<Ok<RefreshTokenResponse>, BadRequest<RefreshTokenResponse>, BadRequest>
            > (HttpContext httpContext, IRefreshTokenUseCase handler) =>
            {
                httpContext.Request.Cookies.TryGetValue("RefreshToken", out var refreshToken);
                if (refreshToken is null)
                {
                    return TypedResults.BadRequest();
                }
                var res = await handler.Handle(new RefreshTokenRequest(refreshToken));
                if (res.IsSuccess)
                {
                    SetTokenInsideCookie(res.AccessToken!, res.RefreshToken!, httpContext);
                    return TypedResults.Ok(res);
                }
                else
                {
                    return TypedResults.BadRequest(res);
                }
            }
        );

        endpoints.MapPost(
            "/refresh/logout",
            async Task<Results<Ok, BadRequest>> (HttpContext httpContext, ILogoutUseCase handler) =>
            {
                httpContext.Request.Cookies.TryGetValue("RefreshToken", out var refreshToken);
                if(refreshToken is not null)
                {
                    await handler.Handle(refreshToken);
                }
                ClearCookies(httpContext);
                return TypedResults.Ok();
            }
        );

        endpoints.MapGet("/info",(
                    HttpContext context
                    ) => {
            if (context.User is ClaimsPrincipal principal)
            {
                var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
                var userEmail = principal.FindFirst(ClaimTypes.Email)?.Value ?? "";
                var firstName = principal.FindFirst("firstName")?.Value ?? "";
                var lastName = principal.FindFirst("lastName")?.Value ?? "";
                var role = principal.FindFirst(ClaimTypes.Role)?.Value ?? "";
                return Results.Ok(new UserInfo(userId, userEmail, firstName,lastName, role));
            } else {
                return Results.BadRequest();
            }
        })
        .RequireAuthorization("UserPermission");

    }

    public static void SetTokenInsideCookie(string accessToken, string refreshToken, HttpContext context)
    {

        context.Response.Cookies.Append(
            "AccessToken",
            accessToken,
            new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(10),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                Domain = "localhost",
                Path = "/",
                SameSite = SameSiteMode.Strict,
            }
        );
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
    public static void ClearCookies(HttpContext context)
    {
        context.Response.Cookies.Delete("AccessToken",
                new CookieOptions
                {
                    Domain = "localhost",
                    Path = "/",
                }
        );
        context.Response.Cookies.Delete("RefreshToken",
            new CookieOptions
            {
                Domain = "localhost",
                Path = "/api/v1/auth/refresh",
            }
        );
    }
}
