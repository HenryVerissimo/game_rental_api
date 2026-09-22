using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GameRentalApi.Core.DTOs;


public class GameRequestDTO
{
    [Required(ErrorMessage = "The 'title' field is required!")]
    [StringLength(150, ErrorMessage = "The 'title' field cannot be longer than 100 characters!")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "The 'description' field is required!")]
    [StringLength(300, ErrorMessage = "The 'description' field cannot be longer than 300 characters!")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "The 'price' field is required!")]
    public decimal Price { get; set; }

    public int ReleaseYear { get; set; }

    public int UnitQuantity { get; set; }

    public int AvailableQuantity { get; set; }

    [StringLength(350, ErrorMessage = "The 'gamecoverimageurl' field cannot be longer than 350 characters!")]
    public string? GameCoverImageUrl { get; set; }

    public int VideoGameId { get; set;}
}