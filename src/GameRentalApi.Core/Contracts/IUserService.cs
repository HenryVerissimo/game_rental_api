using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Contracts;


public interface IUserService
{
    Task<User?> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task<User> CreateAsync(UserRequestDTO userRequestDto);
    Task<bool> UpdateAsync(int id, UserRequestDTO userRequestDto);
    Task<bool> SoftDeleteAsync(int id);  
}