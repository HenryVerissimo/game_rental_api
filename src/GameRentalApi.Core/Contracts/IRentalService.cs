using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IRentalService
{
    Task<Rental?> GetByIdAsync(int id);
    Task<List<Rental>> GetAllAsync();
    Task<Rental> CreateAsync(RentalRequestDTO rentalRequestDto);
    Task<bool> UpdateAsync(int id, RentalRequestDTO rentalRequestDto);
    Task<bool> SoftDeleteAsync(int id);
}