using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.Models;
using GameRentalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameRentalApi.Infrastructure.Repositories;


public class UserRoleRepository : IUserRoleRepository
{
    private readonly AppDbContext _context;

    public UserRoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserRole?> GetByIdAsync(int id)
    {
        UserRole? userRole = await _context.UserRoles.FindAsync(id);
        return userRole;
    }

    public async Task<IEnumerable<UserRole>> GetAllAsync()
    {
        List<UserRole> userRoles = await _context.UserRoles.ToListAsync();
        return userRoles;
    }

    public async Task<UserRole> CreateAsync(UserRole userRole)
    {
        EntityEntry<UserRole> createdUserRole = _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync();

        return createdUserRole.Entity;
    }

    public async Task<UserRole> UpdateAsync(UserRole currentUserRole, UserRole userRole)
    {
        _context.Entry(currentUserRole).CurrentValues.SetValues(userRole);
        await _context.SaveChangesAsync();

        return userRole;
    }

    public async Task DeleteAsync(UserRole userRole)
    {
        _context.UserRoles.Remove(userRole);
        await _context.SaveChangesAsync();
    }
}