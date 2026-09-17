using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.Models;
using GameRentalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameRentalApi.Infrastructure.Repositories;


public class VideoGameRepository : IVideoGameRepository
{
    private readonly AppDbContext _context;

    public VideoGameRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VideoGame?> GetByIdAsync(int id)
    {
        VideoGame? videoGame = await _context.VideoGames.FindAsync(id);
        return videoGame;
    }

    public async Task<IEnumerable<VideoGame>> GetAllAsync()
    {
        List<VideoGame> videogames = await _context.VideoGames.ToListAsync();
        return videogames;
    }

    public async Task<VideoGame> CreateAsync(VideoGame videoGame)
    {
        EntityEntry<VideoGame> createdVideoGame = _context.VideoGames.Add(videoGame);
        await _context.SaveChangesAsync();

        return createdVideoGame.Entity;
    }

    public async Task<VideoGame> UpdateAsync(VideoGame currentVideoGame, VideoGame videoGame)
    {
        _context.Entry(currentVideoGame).CurrentValues.SetValues(videoGame);
        await _context.SaveChangesAsync();

        return videoGame;
    }

    public async Task SoftDeleteAsync(VideoGame videoGame)
    {
        videoGame.DeletedAt = DateTime.UtcNow;
        _context.VideoGames.Update(videoGame);
        await _context.SaveChangesAsync();
    }
}