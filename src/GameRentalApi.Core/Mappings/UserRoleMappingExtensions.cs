using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Mappings;


public static class UserRoleMappingExtensions
{
    public static UserRole ToUserRole(this UserRoleRequestDTO userRoleRequestDto)
    {
        UserRole userRole = new()
        {
          RoleId = userRoleRequestDto.RoleId,
          UserId = userRoleRequestDto.UserId  
        };

        return userRole;
    }

    public static UserRoleResponseDTO ToUserRoleResponseDTO(this UserRole userRole)
    {
        UserRoleResponseDTO userRoleResponseDto = new()
        {
            RoleId = userRole.RoleId,
            UserId = userRole.UserId
        };

        return userRoleResponseDto;
    }

    public static IEnumerable<UserRoleResponseDTO> ToUserRoleResponseDTOList(this IEnumerable<UserRole> userRoles)
    {
        List<UserRoleResponseDTO> userRoleResponseDtoList = new();

        foreach (UserRole userRole in userRoles)
        {
            UserRoleResponseDTO userRoleResponseDto = userRole.ToUserRoleResponseDTO();
            userRoleResponseDtoList.Append(userRoleResponseDto);
        };

        return userRoleResponseDtoList;
    }
}