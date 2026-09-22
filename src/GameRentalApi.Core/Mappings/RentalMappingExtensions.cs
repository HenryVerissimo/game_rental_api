using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Mappings;


public static class RentalMappingExtensions
{
    public static Rental ToRental(this RentalRequestDTO rentalRequestDto)
    {
        Rental rental = new()
        {
          TotalAmount = rentalRequestDto.TotalAmount,
          Deadline = rentalRequestDto.Deadline,
          UserId = rentalRequestDto.UserId
        };

        return rental;
    }

    public static RentalResponseDTO ToRentalResponseDTO(this Rental rental)
    {
        RentalResponseDTO rentalResponseDto = new()
        {
            Id = rental.Id,
            TotalAmount = rental.TotalAmount,
            RentalDate = rental.RentalDate,
            Deadline = rental.Deadline,
            UserId = rental.UserId
        };

        return rentalResponseDto;
    }

    public static IEnumerable<RentalResponseDTO> ToRentalResponseDTO(this IEnumerable<Rental> rentals)
    {
        List<RentalResponseDTO> rentalResponseDtoList = new();

        foreach (Rental rental in rentals)
        {
            RentalResponseDTO rentalResponseDto = rental.ToRentalResponseDTO();
            rentalResponseDtoList.Append(rentalResponseDto);
        }

        return rentalResponseDtoList;
    }
}