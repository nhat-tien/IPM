using System.Security.Claims;

namespace IPM.WebApi.Helper;

public class GetUserIdFromHttpContext
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
