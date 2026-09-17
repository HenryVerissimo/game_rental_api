using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.Models;
using GameRentalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameRentalApi.Infrastructure.Repositories;


public class RentalRepository : IRentalRepository
{
    private readonly AppDbContext _context;

    public RentalRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Rental?> GetByIdAsync(int id)
    {
        Rental? rental = await _context.Rentals.FindAsync(id);
        return rental;
    }

    public async Task<IEnumerable<Rental>> GetAllAsync()
    {
        List<Rental> rentals = await _context.Rentals.ToListAsync();
        return rentals;
    }

    public async Task<Rental> CreateAsync(Rental rental)
    {
        EntityEntry<Rental> CreatedRental = _context.Rentals.Add(rental);
        await _context.SaveChangesAsync();

        return CreatedRental.Entity;
    }

    public async Task<Rental> UpdateAsync(Rental currentRental, Rental rental)
    {
        _context.Entry(currentRental).CurrentValues.SetValues(rental);
        await _context.SaveChangesAsync();

        return rental;
    }

    public async Task SoftDeleteAsync(Rental rental)
    {
        rental.DeletedAt = DateTime.UtcNow;
        _context.Rentals.Update(rental);
        await _context.SaveChangesAsync();
    }
}