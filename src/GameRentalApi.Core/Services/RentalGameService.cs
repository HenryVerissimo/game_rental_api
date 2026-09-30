using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Mappings;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Services; 


public class RentalGameService : IRentalGameService
{
    private readonly IRentalGameRepository _repository;

    public RentalGameService(IRentalGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<RentalGame?> GetByFKsAsync(int gameId, int rentalId)
    {
        RentalGame? rentalGame = await _repository.GetByFKsAsync(gameId, rentalId);
        return rentalGame;
    }

    public async Task<List<RentalGame>> GetAllAsync()
    {
        IEnumerable<RentalGame> rentalGames = await _repository.GetAllAsync();
        return rentalGames.ToList();
    }

    public async Task<RentalGame> CreateAsync(RentalGameRequestDTO rentalGameRequestDto)
    {
        RentalGame rentalGame = rentalGameRequestDto.ToRentalGame();
        RentalGame createdRentalGame = await _repository.CreateAsync(rentalGame);
        return createdRentalGame;
    }

    public async Task<bool> UpdateAsync(int gameId, int rentalId, RentalGameRequestDTO rentalGameRequestDto)
    {
        RentalGame? currentRentalGame = await _repository.GetByFKsAsync(gameId, rentalId);

        if (currentRentalGame is null) return false;

        RentalGame updatedRentalGame = rentalGameRequestDto.ToRentalGame();

        await _repository.UpdateAsync(currentRentalGame, updatedRentalGame);
        return true;
    }

    public async Task<bool> DeleteAsync(int gameId, int rentalId)
    {
        RentalGame? rentalGame = await _repository.GetByFKsAsync(gameId, rentalId);

        if (rentalGame is null) return false;

        await _repository.DeleteAsync(rentalGame);
        return true;
    }
}