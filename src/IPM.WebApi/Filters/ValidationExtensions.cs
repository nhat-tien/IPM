namespace IPM.WebApi.Filters;

  public static class ValidationExtensions
  {
      public static RouteHandlerBuilder WithRequestValidation<TRequest>(this RouteHandlerBuilder builder)
        {
            builder.AddEndpointFilter<ValidationFilter<TRequest>>()
                .ProducesValidationProblem();
            return builder;
        }

  }
 
