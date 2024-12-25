namespace IPM.WebApi.Filters;

  public static class ValidationExtensions
  {
      public static void WithRequestValidation<TRequest>(this RouteHandlerBuilder builder)
        {
            builder.AddEndpointFilter<ValidationFilter<TRequest>>()
                .ProducesValidationProblem();
        }

  }
 
