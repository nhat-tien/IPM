using System.ComponentModel.DataAnnotations;

namespace IPM.Application.UseCases.Auth.RegisterUseCase;
  public class RegisterRequest
  {
      [Required]
      public string Email {get; set;}
  }
 
