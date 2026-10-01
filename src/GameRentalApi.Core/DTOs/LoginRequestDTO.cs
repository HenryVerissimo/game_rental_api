using System.ComponentModel.DataAnnotations;

namespace GameRentalApi.Core.DTOs;


public class LoginRequestDTO
{
    [Required(ErrorMessage = "The 'email' field is required!")]
    [EmailAddress(ErrorMessage = "The 'email' field needs a valid value!")]
    [StringLength(100, ErrorMessage = "The 'email' field cannot be longer than 100 characters!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "The 'password' field is required!")]
    [MinLength(16, ErrorMessage = "The 'password' field needs to be at least 16 characters long!")]
    [MaxLength(64, ErrorMessage = "The 'password' field cannot be longer than 64 characters!")]
    public string Password { get; set; } = string.Empty;
}