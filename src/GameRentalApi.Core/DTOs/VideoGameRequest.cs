using System.ComponentModel.DataAnnotations;

namespace GameRentalApi.Core.DTOs;


public class VideoGameRequestDTO
{
    [Required(ErrorMessage = "The 'name' field is required!")]
    [StringLength(100, ErrorMessage = "The 'name' field cannot be longer than 100 characters!")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "The 'company' field is required!")]
    [StringLength(100, ErrorMessage = "The 'company' field cannot be longer than 100 characters!")]
    public string Company { get; set; } = string.Empty;  
}