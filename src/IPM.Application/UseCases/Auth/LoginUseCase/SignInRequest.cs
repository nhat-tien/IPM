using System.ComponentModel.DataAnnotations;

namespace IPM.Application.UseCases.Auth.LoginUseCase;

  public class SignInRequest
  {
      [Required]
      public string FirstName {get; set;} = "";

      [Required]
      public string LastName {get; set;} = "";
  }
 
