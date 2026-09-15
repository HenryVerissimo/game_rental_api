namespace GameRentalApi.Api.Models;


public class UserRole
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}