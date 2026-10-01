using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalApi.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RentalGamesController : ControllerBase
{
    private readonly IRentalGameService _service;

    public RentalGamesController(IRentalGameService service)
    {
        _service = service;
    }

    [Authorize]
    [HttpGet("{gameId:int}/{rentalId:int}")]
    public async Task<ActionResult<RentalGame>> GetByFKsAsync([FromRoute] int gameId, [FromRoute] int rentalId)
    {
        RentalGame? rentalGame = await _service.GetByFKsAsync(gameId, rentalId);

        if (rentalGame is RentalGame) return Ok(rentalGame);

        return NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentalGame>>> GetAllAsync()
    {
        List<RentalGame> rentalGames = await _service.GetAllAsync();
        return Ok(rentalGames);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<RentalGame>> CreateAsync([FromBody] RentalGameRequestDTO rentalGameRequestDto)
    {
        RentalGame created = await _service.CreateAsync(rentalGameRequestDto);
        return CreatedAtAction(nameof(GetByFKsAsync), new { gameId = created.GameId, rentalId = created.RentalId}, created);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{gameId:int}/{rentalId:int}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int gameId, [FromRoute] int rentalId, [FromBody] RentalGameRequestDTO rentalGameRequestDto)
    {
        bool isUpdated = await _service.UpdateAsync(gameId, rentalId, rentalGameRequestDto);

        if (isUpdated) return NoContent();

        return NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{gameId:int}/{rentalId:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int gameId, [FromRoute] int rentalId)
    {
        bool isDeleted = await _service.DeleteAsync(gameId, rentalId);

        if (isDeleted) return NoContent();

        return NotFound();
    }
}