namespace GameRentalApi.Core.DTOs;


public class GameResponseDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int ReleaseYear { get; set; }
    public int UnitQuantity { get; set; }
    public int AvailableQuantity { get; set; }
    public string? GameCoverImageUrl { get; set; }

    public int VideoGameId { get; set;}
}