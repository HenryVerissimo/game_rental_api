using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IRentalGameRepository
{
    Task<RentalGame?> GetByIdAsync(int id);
    Task<IEnumerable<RentalGame>> GetAllAsync();
    Task<RentalGame> CreateAsync(RentalGame rentalGame);
    Task<RentalGame> UpdateAsync(RentalGame currentRentalGame, RentalGame rentalGame);
    Task DeleteAsync(RentalGame rentalGame);
}