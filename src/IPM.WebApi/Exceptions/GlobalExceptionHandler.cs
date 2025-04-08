using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace IPM.WebApi.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        var problemDetails = new ProblemDetails 
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error",
            Type = exception.GetType().Name,
            Detail = exception.Message
        };

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}

