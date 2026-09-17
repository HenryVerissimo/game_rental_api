using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IRentalRepository
{
    Task<Rental?> GetByIdAsync(int id);
    Task<IEnumerable<Rental>> GetAllAsync();
    Task<Rental> CreateAsync(Rental rental);
    Task<Rental> UpdateAsync(Rental currentRental, Rental rental);
    Task SoftDeleteAsync(Rental rental);
}