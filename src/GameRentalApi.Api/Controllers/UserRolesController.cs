using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalApi.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IUserRoleService _service;

    public UserRolesController(IUserRoleService service)
    {
        _service = service;
    }

    [HttpGet("{roleId:int}/{userId:int}")]
    public async Task<ActionResult<UserRole>> GetByFKsAsync([FromRoute] int roleId, [FromRoute] int userId)
    {
        UserRole? userRole = await _service.GetByFKsAsync(roleId, userId);

        if (userRole is UserRole) return Ok(userRole);

        return NoContent(); 
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserRole>>> GetAllAsync()
    {
        List<UserRole> userRoles = await _service.GetAllAsync();
        return Ok(userRoles);
    }

    [HttpPost]
    public async Task<ActionResult<UserRole>> CreateAsync(UserRoleRequestDTO userRoleRequestDto)
    {
        UserRole userRole = await _service.CreateAsync(userRoleRequestDto);
        return CreatedAtAction(nameof(GetByFKsAsync), new { roleId = userRole.RoleId, userId = userRole.UserId }, userRole);
    }

    [HttpPut("{roleId:int}/{userId:int}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int roleId, [FromRoute] int userId, [FromBody] UserRoleRequestDTO userRoleRequestDto)
    {
        bool isUpdated = await _service.UpdateAsync(roleId, userId, userRoleRequestDto);

        if (isUpdated) return NoContent();

        return NotFound();
    }

    [HttpDelete("{roleId:int}/{userId:int}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int roleId, [FromRoute] int userId)
    {
        bool isDeleted = await _service.DeleteAsync(roleId, userId);

        if (isDeleted) return NoContent();

        return NotFound();
    }
}