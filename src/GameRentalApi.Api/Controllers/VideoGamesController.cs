using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalApi.Api.Controllers;


public class VideoGamesController : ControllerBase
{
    private readonly IVideoGameService _service;

    public VideoGamesController(IVideoGameService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<VideoGame>> GetByIdAsync([FromRoute] int id)
    {
        VideoGame? videoGame = await _service.GetByIdAsync(id);

        if (videoGame is VideoGame) return Ok(videoGame);

        return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VideoGame>>> GetAllAsync()
    {
        List<VideoGame> videoGames = await _service.GetAllAsync();
        return Ok(videoGames);
    }

    [HttpPost]
    public async Task<ActionResult<VideoGame>> CreateAsync([FromBody] VideoGameRequestDTO videoGameRequestDto)
    {
        VideoGame videoGame = await _service.CreateAsync(videoGameRequestDto);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = videoGame.Id }, videoGame);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] VideoGameRequestDTO videoGameRequestDto)
    {
        bool isUpdated = await _service.UpdateAsync(id, videoGameRequestDto);

        if (isUpdated) return NoContent();

        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> SoftDelete([FromRoute] int id)
    {
        bool isDeleted = await _service.SoftDeleteAsync(id);

        if (isDeleted) return NoContent();

        return NotFound();
    }
}