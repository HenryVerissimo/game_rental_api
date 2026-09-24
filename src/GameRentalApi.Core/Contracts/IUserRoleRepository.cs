using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IUserRoleRepository
{
    Task<UserRole?> GetByFKsAsync(int roleId, int userId);
    Task<IEnumerable<UserRole>> GetAllAsync();
    Task<UserRole> CreateAsync(UserRole userRole);
    Task<UserRole> UpdateAsync(UserRole currentUserRole, UserRole userRole);
    Task DeleteAsync(UserRole userRole);
}