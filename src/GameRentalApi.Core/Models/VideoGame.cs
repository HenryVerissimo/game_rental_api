namespace GameRentalApi.Api.Models;

public class VideoGame
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Company { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Game> Games { get; set; } = new List<Game>();
}