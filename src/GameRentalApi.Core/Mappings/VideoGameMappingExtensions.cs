using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Mappings;


public static class VideoGameMappingExtensions
{
    public static VideoGame ToVideoGame(this VideoGameRequestDTO videoGameRequestDto)
    {
        VideoGame videoGame = new()
        {
          Name = videoGameRequestDto.Name,
          Company = videoGameRequestDto.Company  
        };

        return videoGame;
    }

    public static VideoGameResponseDTO ToVideoGameResponseDTO(this VideoGame videoGame)
    {
        VideoGameResponseDTO videoGameResponseDto = new()
        {
            Name = videoGame.Name,
            Company = videoGame.Company
        };

        return videoGameResponseDto;
    }

    public static IEnumerable<VideoGameResponseDTO> ToVideoGameResponseDTOList(this IEnumerable<VideoGame> videoGames)
    {
        List<VideoGameResponseDTO> videoGameResponseDtoList = new();

        foreach (VideoGame videoGame in videoGames)
        {
            VideoGameResponseDTO videoGameResponseDto = videoGame.ToVideoGameResponseDTO();
            videoGameResponseDtoList.Append(videoGameResponseDto);
        }

        return videoGameResponseDtoList;
    }
}