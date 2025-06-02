using IPM.Infrastructure.Exceptions;
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
        ProblemDetails problemDetails;
        if(exception is DbException dbException) {
            problemDetails = new ProblemDetails 
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Database Error",
                Type = dbException.GetType().Name + "." + dbException.Type,
                Detail = dbException.Location + ": " + dbException.Message
            };
        } else {
            problemDetails = new ProblemDetails 
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error",
                Type = exception.GetType().Name,
                Detail = exception.Message
            };
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}

