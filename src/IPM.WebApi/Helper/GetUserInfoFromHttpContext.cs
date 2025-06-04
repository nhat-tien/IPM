namespace IPM.WebApi.Helper;
using System.Security.Claims;

public class GetUserInfoFromHttpContext
{
    public static string? Get(HttpContext context) 
    {
            if (context.User is ClaimsPrincipal principal)
            {
                return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            return null;
    }
}
