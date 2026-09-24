using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IRoleService
{
    Task<Role?> GetByIdAsync(int id);
    Task<List<Role>> GetAllAsync();
    Task<Role> CreateAsync(RoleRequestDTO roleRequestDto);
    Task<bool> UpdateAsync(int id, RoleRequestDTO roleRequestDto);
    Task<bool> SoftDeleteAsync(int id);    
}