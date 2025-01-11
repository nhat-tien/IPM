using Microsoft.AspNetCore.Authorization;
namespace IPM.WebApi.Policies.Requirements;

public class SameOwnerRequirement: IAuthorizationRequirement
{
}
