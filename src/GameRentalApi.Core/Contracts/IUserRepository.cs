using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User currentUser, User user);
    Task SoftDeleteAsync(User user);
}