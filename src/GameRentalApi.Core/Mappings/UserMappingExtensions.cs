using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Mappings;


public static class UserMappingExtensions
{
    public static User ToUser(this UserRequestDTO userRequestDto, string passwordHash)
    {
        User user = new()
        {
            Name = userRequestDto.Name,
            Email = userRequestDto.Email,
            PasswordHash = passwordHash,
            PhoneNumber = userRequestDto.PhoneNumber,
        };

        return user;
    }

    public static UserResponseDTO ToUserResponseDTO(this User user)
    {
        UserResponseDTO userResponseDto = new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber     
        };

        return userResponseDto;

    }

    public static IEnumerable<UserResponseDTO> ToUserResponseDTOList(this IEnumerable<User> users)
    {
        List<UserResponseDTO> userResponseDtoList = new();

        foreach (User user in users)
        {
            UserResponseDTO userResponseDto = user.ToUserResponseDTO();
            userResponseDtoList.Append(userResponseDto);
        }

        return userResponseDtoList;
    }
}