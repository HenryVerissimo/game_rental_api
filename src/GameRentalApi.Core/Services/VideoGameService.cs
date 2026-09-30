using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Mappings;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Services;


public class VideoGameService : IVideoGameService
{
    private readonly IVideoGameRepository _repository;

    public VideoGameService(IVideoGameRepository repository)
    {
        _repository = repository;
    }

    public async Task<VideoGame?> GetByIdAsync(int id)
    {
        VideoGame? videoGame = await _repository.GetByIdAsync(id);
        return videoGame;
    }

    public async Task<List<VideoGame>> GetAllAsync()
    {
        IEnumerable<VideoGame> videoGames = await _repository.GetAllAsync();
        return videoGames.ToList();
    }

    public async Task<VideoGame> CreateAsync(VideoGameRequestDTO videoGameRequestDto)
    {
        VideoGame videoGame = videoGameRequestDto.ToVideoGame();
        VideoGame newVideogame = await _repository.CreateAsync(videoGame);
        return newVideogame;
    }

    public async Task<bool> UpdateAsync(int id, VideoGameRequestDTO videoGameRequestDto)
    {
        VideoGame? currentVideoGame = await _repository.GetByIdAsync(id);

        if (currentVideoGame is null) return false;

        VideoGame updatedVideoGame = videoGameRequestDto.ToVideoGame();
        await _repository.UpdateAsync(currentVideoGame, updatedVideoGame);
        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        VideoGame? videoGame = await _repository.GetByIdAsync(id);

        if (videoGame is null) return false;

        await _repository.SoftDeleteAsync(videoGame);
        return true;
    }
}