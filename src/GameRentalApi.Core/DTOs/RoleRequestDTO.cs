using System.ComponentModel.DataAnnotations;

namespace GameRentalApi.Core.DTOs;


public class RoleRequestDTO
{
    [Required(ErrorMessage = "The 'name' field is required!")]
    [StringLength(100, ErrorMessage = "The 'name' field cannot be longer than 100 characters!")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "The 'description' field is required!")]
    [StringLength(300, ErrorMessage = "The 'description' field cannot be longer than 300 characters!")]
    public string Description { get; set; } = string.Empty;  
}