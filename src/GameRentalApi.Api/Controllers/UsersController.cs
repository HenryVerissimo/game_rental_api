using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalApi.Api.Controllers;


public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetByIdAsync([FromRoute] int id)
    {
        User? user = await _service.GetByIdAsync(id);

        if (user is User) return Ok(user);

        return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
    {
        List<User> users = await _service.GetAllAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync([FromBody] UserRequestDTO userRequestDto)
    {
        User user = await _service.CreateAsync(userRequestDto);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = user.Id }, user);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] UserRequestDTO userRequestDto)
    {
        bool isUpdated = await _service.UpdateAsync(id, userRequestDto);

        if (isUpdated) return NoContent();

        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> SoftDeleteAsync([FromRoute] int id)
    {
        bool isDelted = await _service.SoftDeleteAsync(id);

        if (isDelted) return NoContent();

        return NotFound();
    }
}