using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.Models;
using GameRentalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameRentalApi.Infrastructure.Repositories;


public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository (AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? user = await _context.Users.FindAsync(id);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        List<User> users = await _context.Users.ToListAsync();
        return users;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> createdUser = _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return createdUser.Entity;
    }

    public async Task<User> UpdateAsync(User currentUser, User user)
    {
        _context.Entry(currentUser).CurrentValues.SetValues(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task SoftDeleteAsync(User user)
    {
        user.DeletedAt = DateTime.UtcNow;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}