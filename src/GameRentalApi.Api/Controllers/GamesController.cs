using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalApi.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _service;

    public GamesController(IGameService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Game>> GetByIdAsync([FromRoute] int id)
    {
        Game? game = await _service.GetByIdAsync(id);

        if (game is Game) return Ok(game);

        return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> GetAllAsync()
    {
        List<Game> games = await _service.GetAllAsync();
        return Ok(games);
    }

    [HttpPost]
    public async Task<ActionResult<Game>> CreateAsync([FromBody] GameRequestDTO gameRequestDto)
    {
        Game game = await _service.CreateAsync(gameRequestDto);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = game.Id}, game);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] GameRequestDTO gameRequestDto)
    {
        bool isUpdated = await _service.UpdateAsync(id, gameRequestDto);

        if (isUpdated) return NoContent();

        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> SoftDeleteAsync([FromRoute] int id)
    {
        bool isDeleted = await _service.SoftDeleteAsync(id);

        if (isDeleted) return NoContent();

        return NotFound();
    }
}