using System.ComponentModel.DataAnnotations;

namespace GameRentalApi.Core.DTOs;


public class RentalRequestDTO
{
    [Required(ErrorMessage = "The 'totalamount' field is required!")]
    public decimal TotalAmount { get; set; }

    public DateTime Deadline { get; set; }

    public int UserId { get; set; }
}