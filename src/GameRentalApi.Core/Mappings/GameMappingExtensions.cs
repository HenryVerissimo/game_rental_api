using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;

namespace GameRentalApi.Core.Mappings;


public static class GameMappingExtensions
{
    public static Game ToGame(this GameRequestDTO gameRequestDto)
    {
        Game game = new()
        {
            Title = gameRequestDto.Title,
            Description = gameRequestDto.Description,
            Price = gameRequestDto.Price,
            ReleaseYear = gameRequestDto.ReleaseYear,
            UnitQuantity = gameRequestDto.UnitQuantity,
            AvailableQuantity = gameRequestDto.AvailableQuantity,
            GameCoverImageUrl = gameRequestDto.GameCoverImageUrl,
            VideoGameId = gameRequestDto.VideoGameId
        };

        return game;
    }

    public static GameResponseDTO ToGameResponseDTO(this Game game)
    {
        GameResponseDTO gameResponseDto = new()
        {
            Id = game.Id,
            Title = game.Title,
            Description = game.Description,
            Price = game.Price,
            ReleaseYear = game.ReleaseYear,
            UnitQuantity = game.UnitQuantity,
            AvailableQuantity = game.AvailableQuantity,
            GameCoverImageUrl = game.GameCoverImageUrl,
            VideoGameId = game.VideoGameId
        };

        return gameResponseDto;
    }

    public static IEnumerable<GameResponseDTO> ToGameResponseDTOList(this IEnumerable<Game> games)
    {
        List<GameResponseDTO> gameResponseDtoList = new();

        foreach (Game game in games)
        {
            GameResponseDTO gameResponseDto = game.ToGameResponseDTO();
            gameResponseDtoList.Append(gameResponseDto);
        }

        return gameResponseDtoList;
    }
}