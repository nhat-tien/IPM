namespace IPM.WebApi.ApiEndPoints.V1;

using IPM.Application.UseCases.Auth.LoginUseCase;
using IPM.Application.UseCases.Auth.RegisterUseCase;
using IPM.Application.UseCases.Auth.RefreshTokenUseCase;
using IPM.WebApi.Filters;

public class AuthEndPoint
{
    public static void Map(RouteGroupBuilder endpoints)
    {
        endpoints.MapPost(
            "/login",
            async (SignInRequest req,HttpContext httpContext, ILoginUseCase handler) =>
            {
                var res = await handler.Handle(req);
                if (res.IsSuccess)
                {
                    SetTokenInsideCookie(res.AccessToken!, httpContext);
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
            async (RefreshTokenRequest req, HttpContext httpContext, IRefreshTokenUseCase handler) =>
            {
                var res = await handler.Handle(req);
                if (res.IsSuccess)
                {
                    SetTokenInsideCookie(res.AccessToken!, httpContext);
                    return Results.Ok(res);
                }
                else
                {
                    return Results.BadRequest(res);
                }
            }
        );
    }

    public static void SetTokenInsideCookie(string accessToken, HttpContext context)
    {
        context.Response.Cookies.Append("AccessToken", accessToken, new CookieOptions {
                Expires = DateTime.Now.AddMinutes(50),
                HttpOnly = true,
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
        });
    }
}
