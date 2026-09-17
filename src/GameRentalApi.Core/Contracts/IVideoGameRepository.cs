using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IVideoGameRepository
{
    Task<VideoGame?> GetByIdAsync(int id);
    Task<IEnumerable<VideoGame>> GetAllAsync();
    Task<VideoGame> CreateAsync(VideoGame videoGame);
    Task<VideoGame> UpdateAsync(VideoGame currentVideoGame, VideoGame videoGame);
    Task SoftDeleteAsync(VideoGame videogame);
}