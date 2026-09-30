using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Mappings;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Services;


public class RentalService : IRentalService
{
    private readonly IRentalRepository _repository;
    
    public RentalService(IRentalRepository repository)
    {
        _repository = repository;
    }

    public async Task<Rental?> GetByIdAsync(int id)
    {
        Rental? rental = await _repository.GetByIdAsync(id);
        return rental;
    }

    public async Task<List<Rental>> GetAllAsync()
    {
        IEnumerable<Rental> rentals = await _repository.GetAllAsync();
        return rentals.ToList();
    }

    public async Task<Rental> CreateAsync(RentalRequestDTO rentalRequestDto)
    {
        Rental rental = rentalRequestDto.ToRental();
        Rental createdRental = await _repository.CreateAsync(rental);
        return createdRental;
    }

    public async Task<bool> UpdateAsync(int id, RentalRequestDTO rentalRequestDto)
    {
        Rental? currentRental = await _repository.GetByIdAsync(id);

        if (currentRental is null) return false;

        Rental updatedRental = rentalRequestDto.ToRental();

        await _repository.UpdateAsync(currentRental, updatedRental);
        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        Rental? rental = await _repository.GetByIdAsync(id);

        if (rental is null) return false;

        await _repository.SoftDeleteAsync(rental);
        return true;
    } 
}