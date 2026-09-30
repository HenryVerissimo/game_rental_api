using System.Security.Cryptography;
using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Mappings;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Services;


public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IPasswordHasherService _hasher;

    public UserService(IUserRepository repository, IPasswordHasherService hasher)
    {
        _repository = repository;
        _hasher = hasher;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? user = await _repository.GetByIdAsync(id);
        return user;
    }

    public async Task<List<User>> GetAllAsync()
    {
        IEnumerable<User> users = await _repository.GetAllAsync();
        return users.ToList();
    }

    public async Task<User> CreateAsync(UserRequestDTO userRequestDto)
    {
        if (userRequestDto.Password != userRequestDto.ConfirmPassword)
        {
            throw new ArgumentException("Password and confirmation password do not match.");
        }

        User user = userRequestDto.ToUser();
        string passwordHash = _hasher.CreateHash(user, userRequestDto.Password);
        user.PasswordHash = passwordHash;

        User newUser = await _repository.CreateAsync(user);
        return newUser;
    }

    public async Task<bool> UpdateAsync(int id, UserRequestDTO userRequestDto)
    {
        User? currentUser = await _repository.GetByIdAsync(id);

        if (currentUser is null) return false;

        User updatedUser = userRequestDto.ToUser();
        await _repository.UpdateAsync(currentUser, updatedUser);
        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        User? user = await _repository.GetByIdAsync(id);

        if (user is null) return false;

        await _repository.SoftDeleteAsync(user);
        return true;
    }
}