namespace GameRentalApi.Core.DTOs;



public class RentalGameResponseDTO
{
    public decimal UnitGamePrice { get; set; }
    public int Quantity { get; set; }
    public DateTime? ReturnedAt { get; set; }

    public int RentalId { get; set; }
    public int GameId { get; set; }
}