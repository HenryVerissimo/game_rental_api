using System.ComponentModel.DataAnnotations.Schema;

namespace GameRentalApi.Api.Models;


public class RentalGame
{
    public decimal UnitGamePrice { get; set; }
    public int Quantity { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public int RentalId { get; set; }
    public Rental Rental { get; set; } = null!;

    public int GameId { get; set; }
    public Game Game { get; set; } = null!;
}