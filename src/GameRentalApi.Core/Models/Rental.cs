using System.ComponentModel.DataAnnotations.Schema;

namespace GameRentalApi.Core.Models;


public class Rental
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime RentalDate { get; set; } = DateTime.UtcNow;
    public DateTime Deadline { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; } = null;

    public int UserId { get; set; }
    public User User {get; set; } = null!;
    public ICollection<RentalGame> RentalGames { get; set; }= new List<RentalGame>();
}