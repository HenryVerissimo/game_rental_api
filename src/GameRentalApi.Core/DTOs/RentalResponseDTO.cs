namespace GameRentalApi.Core.DTOs;


public class RentalResponseDTO
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime Deadline { get; set; }

    public int UserId { get; set; }
}