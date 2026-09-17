using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IRoleRepository
{
    Task<Role?> GetByIdAsync(int id);
    Task<IEnumerable<Role>> GetAllAsync();
    Task<Role> CreateAsync(Role role);
    Task<Role> UpdateAsync(Role currentRole, Role role);
    Task SoftDeleteAsync(Role role);
}