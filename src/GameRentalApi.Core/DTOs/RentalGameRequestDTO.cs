using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameRentalApi.Core.DTOs;


public class RentalGameRequestDTO
{
    [Required(ErrorMessage = "The 'unitgameprice' field is required!")]
    public decimal UnitGamePrice { get; set; }

    public int Quantity { get; set; } = 1;

    public int RentalId { get; set; }

    public int GameId { get; set; }
}