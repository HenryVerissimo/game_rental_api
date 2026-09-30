using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Mappings;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Services;


public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Role?> GetByIdAsync(int id)
    {
        Role? role = await _repository.GetByIdAsync(id);
        return role;
    }

    public async Task<List<Role>> GetAllAsync()
    {
        IEnumerable<Role> roles = await _repository.GetAllAsync();
        return roles.ToList();
    }

    public async Task<Role> CreateAsync(RoleRequestDTO roleRequestDto)
    {
        Role role = roleRequestDto.ToRole();
        Role createdRole = await _repository.CreateAsync(role);
        return createdRole;
    }

    public async Task<bool> UpdateAsync(int id, RoleRequestDTO roleRequestDto)
    {
        Role? currentRole = await _repository.GetByIdAsync(id);

        if (currentRole is null) return false;

        Role updatedRole = roleRequestDto.ToRole();
        await _repository.UpdateAsync(currentRole, updatedRole);
        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        Role? role = await _repository.GetByIdAsync(id);

        if (role is null) return false;

        await _repository.SoftDeleteAsync(role);
        return true;
    }
}