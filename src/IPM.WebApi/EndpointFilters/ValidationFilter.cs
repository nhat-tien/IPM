using FluentValidation;

namespace IPM.WebApi.EndpointFilters;

public class ValidationFilter<TRequest> : IEndpointFilter
{
    private readonly IValidator<TRequest> validator;

    public ValidationFilter(IValidator<TRequest> validator)
    {
        this.validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next
    ) {
        var req = context.Arguments.OfType<TRequest>().First();
        var result = await validator.ValidateAsync(req, context.HttpContext.RequestAborted);
        if (!result.IsValid) {
            return TypedResults.ValidationProblem(result.ToDictionary());
        }
        return await next(context);
    }
}
