using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.Models;
using GameRentalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameRentalApi.Infrastructure.Repositories;


public class RentalGameRepository : IRentalGameRepository
{
    private readonly AppDbContext _context;

    public RentalGameRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RentalGame?> GetByFKsAsync(int gameId, int rentalId)
    {
        RentalGame? rentalGame = await _context.RentalGames.FirstOrDefaultAsync(rentalGame => 
            (rentalGame.GameId == gameId) && (rentalGame.RentalId == rentalId));
            
        return rentalGame;
    }

    public async Task<IEnumerable<RentalGame>> GetAllAsync()
    {
        List<RentalGame> rentalGames = await _context.RentalGames.ToListAsync();
        return rentalGames;
    }

    public async Task<RentalGame> CreateAsync(RentalGame rentalGame)
    {
        EntityEntry<RentalGame> createdRentalGame = _context.RentalGames.Add(rentalGame);
        await _context.SaveChangesAsync();

        return createdRentalGame.Entity;
    }

    public async Task<RentalGame> UpdateAsync(RentalGame currentRentalGame, RentalGame rentalGame)
    {
        _context.Entry(currentRentalGame).CurrentValues.SetValues(rentalGame);
        await _context.SaveChangesAsync();

        return rentalGame;
    }

    public async Task DeleteAsync(RentalGame rentalGame)
    {
        _context.RentalGames.Remove(rentalGame);
        await _context.SaveChangesAsync();
    }
}