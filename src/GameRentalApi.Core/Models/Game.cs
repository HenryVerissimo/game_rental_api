using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameRentalApi.Api.Models;


public class Game
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int ReleaseYear { get; set; }
    public int UnitQuantity { get; set; }
    public int AvailableQuantity { get; set; }
    public string? GameCoverImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public int VideoGameId { get; set;}
    public VideoGame VideoGame { get; set; } = null!;
    public ICollection<RentalGame> RentalGames { get; set; } = new List<RentalGame>();
}