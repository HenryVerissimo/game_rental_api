using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Mappings;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Services;


public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _repository;

    public UserRoleService(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserRole?> GetByFKsAsync(int roleId, int userId)
    {
        UserRole? userRole = await _repository.GetByFKsAsync(roleId, userId);
        return userRole;
    }

    public async Task<List<UserRole>> GetByUserIdAsync(int userId)
    {
        IEnumerable<UserRole> userRoles = await _repository.GetByUserIdAsync(userId);
        return userRoles.ToList();
    }

    public async Task<List<UserRole>> GetAllAsync()
    {
        IEnumerable<UserRole> userRoles = await _repository.GetAllAsync();
        return userRoles.ToList();
    }

    public async Task<UserRole> CreateAsync(UserRoleRequestDTO userRolerequestDto)
    {
        UserRole userRole = userRolerequestDto.ToUserRole();
        UserRole createdUserRole = await _repository.CreateAsync(userRole);
        return createdUserRole;
    }

    public async Task<bool> UpdateAsync(int roleId, int userId, UserRoleRequestDTO userRoleRequestDto)
    {
        UserRole? currentUserRole = await _repository.GetByFKsAsync(roleId, userId);

        if (currentUserRole is null) return false;

        UserRole updatedUserRole = userRoleRequestDto.ToUserRole();
        updatedUserRole.RoleId = currentUserRole.RoleId;
        updatedUserRole.UserId = currentUserRole.UserId;

        await _repository.UpdateAsync(currentUserRole, updatedUserRole);
        return true;
    }

    public async Task<bool> DeleteAsync(int roleId, int userId)
    {
        UserRole? userRole = await _repository.GetByFKsAsync(roleId, userId);

        if (userRole is null) return false;

        await _repository.DeleteAsync(userRole);
        return true;
    }
}