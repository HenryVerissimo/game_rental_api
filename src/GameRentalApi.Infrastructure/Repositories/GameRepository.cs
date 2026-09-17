using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.Models;
using GameRentalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameRentalApi.Infrastructure.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;

    public GameRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        Game? game = await _context.Games.FindAsync(id);
        return game;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        List<Game> games = await _context.Games.ToListAsync();
        return games;
    }

    public async Task<Game> CreateAsync(Game game)
    {
        EntityEntry<Game> createdGame = _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return createdGame.Entity;
    }

    public async Task<Game> UpdateAsync(Game currentGame, Game game)
    {
        _context.Entry(currentGame).CurrentValues.SetValues(game);
        await _context.SaveChangesAsync();

        return game;
    }

    public async Task SoftDeleteAsync(Game game)
    {
        game.DeletedAt = DateTime.UtcNow;
        _context.Games.Update(game);
        await _context.SaveChangesAsync();
    }
}