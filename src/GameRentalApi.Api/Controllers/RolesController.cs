using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalApi.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _service;

    public RolesController(IRoleService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Role>> GetByIdAsync([FromRoute] int id)
    {
        Role? role = await _service.GetByIdAsync(id);

        if (role is Role) return Ok(role);

        return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Role>>> GetAllAsync()
    {
        List<Role> roles = await _service.GetAllAsync();
        return Ok(roles);
    }

    [HttpPost]
    public async Task<ActionResult<Role>> CreateAsync([FromBody] RoleRequestDTO roleRequestDto)
    {
        Role role = await _service.CreateAsync(roleRequestDto);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = role.Id }, role);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] RoleRequestDTO roleRequestDto)
    {
        bool isUpdated = await _service.UpdateAsync(id, roleRequestDto);

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