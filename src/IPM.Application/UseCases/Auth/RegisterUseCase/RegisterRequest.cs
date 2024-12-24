using System.ComponentModel.DataAnnotations;

namespace IPM.Application.UseCases.Auth.RegisterUseCase;

public class RegisterRequest
{
    [Required(ErrorMessage="Trường email là bắt buộc")]
    public string Email { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Password { get; set; }
}
