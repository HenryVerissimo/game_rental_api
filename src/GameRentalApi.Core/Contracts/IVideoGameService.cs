using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IVideoGameService
{
    Task<VideoGame?> GetByIdAsync(int id);
    Task<List<VideoGame>> GetAllAsync();
    Task<VideoGame> CreateAsync(VideoGameRequestDTO videoGameRequestDto);
    Task<bool> UpdateAsync(int id, VideoGameRequestDTO videoGameRequestDto);
    Task<bool> SoftDeleteAsync(int id); 
}