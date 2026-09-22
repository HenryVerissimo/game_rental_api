using System.ComponentModel.DataAnnotations;

namespace GameRentalApi.Core.DTOs;


public class UserRoleRequestDTO
{
    [Required(ErrorMessage = "The 'roleid' field is required!")]
    public int RoleId { get; set; }

    [Required(ErrorMessage = "The 'userid' field is required!")]
    public int UserId { get; set; }  
}