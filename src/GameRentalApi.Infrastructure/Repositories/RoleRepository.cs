using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.Models;
using GameRentalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GameRentalApi.Infrastructure.Repositories;


public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Role?> GetByIdAsync(int id)
    {
        Role? role = await _context.Roles.FindAsync(id);
        return role;
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        List<Role> roles = await _context.Roles.ToListAsync();
        return roles;
    }

    public async Task<Role> CreateAsync(Role role)
    {
        EntityEntry<Role> createdRole = _context.Roles.Add(role);
        await _context.SaveChangesAsync();

        return createdRole.Entity;
    }

    public async Task<Role> UpdateAsync(Role currentRole, Role role)
    {
        _context.Entry(currentRole).CurrentValues.SetValues(role);
        await _context.SaveChangesAsync();

        return role;
    }

    public async Task SoftDeleteAsync(Role role)
    {
        role.DeletedAt = DateTime.UtcNow;
        _context.Roles.Update(role);

        await _context.SaveChangesAsync();
    }
}