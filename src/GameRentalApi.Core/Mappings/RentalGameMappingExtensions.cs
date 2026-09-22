using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Mappings;


public static class RentalGameMappingExtensions
{
    public static RentalGame ToRentalGame(this RentalGameRequestDTO rentalGameRequestDto)
    {
        RentalGame rentalGame = new()
        {
            UnitGamePrice = rentalGameRequestDto.UnitGamePrice,
            Quantity = rentalGameRequestDto.Quantity,
            RentalId = rentalGameRequestDto.RentalId,
            GameId = rentalGameRequestDto.GameId
        };

        return rentalGame;
    }

    public static RentalGameResponseDTO ToRentalGameResponseDTO(this RentalGame rentalGame)
    {
        RentalGameResponseDTO rentalGameResponseDto = new()
        {
            UnitGamePrice = rentalGame.UnitGamePrice,
            Quantity = rentalGame.Quantity,
            ReturnedAt = rentalGame.ReturnedAt,
            RentalId = rentalGame.RentalId,
            GameId = rentalGame.GameId
        };

        return rentalGameResponseDto;
    }

    public static IEnumerable<RentalGameResponseDTO> ToRentalGameResponseDTOList(this IEnumerable<RentalGame> rentalGames)
    {
        List<RentalGameResponseDTO> rentalGameResponseDtoList = new();

        foreach (RentalGame rentalGame in rentalGames)
        {
            RentalGameResponseDTO rentalGameResponseDto = rentalGame.ToRentalGameResponseDTO();
            rentalGameResponseDtoList.Append(rentalGameResponseDto);
        }

        return rentalGameResponseDtoList;
    }
}