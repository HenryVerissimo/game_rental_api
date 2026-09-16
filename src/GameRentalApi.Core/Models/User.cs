using System.ComponentModel.DataAnnotations;

namespace GameRentalApi.Core.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public DateTime? DeletedAt { get; set; } = null;

    public ICollection<UserRole> UserRoles { get; set; }= new List<UserRole>();
    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
