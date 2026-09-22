using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Mappings;


public static class RoleMappingExtensions
{
    public static Role ToRole(this RoleRequestDTO roleRequestDto)
    {
        Role role = new()
        {
            Name = roleRequestDto.Name,
            Description = roleRequestDto.Description
        };

        return role;
    }

    public static RoleResponseDTO ToRoleResponseDTO(this Role role)
    {
        RoleResponseDTO roleResponseDto = new()
        {
            Name = role.Name,
            Description = role.Description
        };

        return roleResponseDto;
    }

    public static IEnumerable<RoleResponseDTO> ToRoleResponseDTOList(this IEnumerable<Role> roles)
    {
        List<RoleResponseDTO> roleResponseDtoList = new();

        foreach (Role role in roles)
        {
            RoleResponseDTO roleResponseDto = role.ToRoleResponseDTO();
            roleResponseDtoList.Append(roleResponseDto);
        }

        return roleResponseDtoList;
    }
}