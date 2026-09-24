using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IUserRoleService
{
    Task<UserRole?> GetByFKsAsync(int roleId, int userId);
    Task<List<UserRole>> GetAllAsync();
    Task<UserRole> CreateAsync(UserRoleRequestDTO userRoleRequestDto);
    Task<bool> UpdateAsync(int roleId, int userId, UserRoleRequestDTO userRoleRequestDto);
    Task<bool> DeleteAsync(int roleId, int userId);
}