using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.DTOs;
using GameRentalApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalApi.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RentalsController : ControllerBase
{
    private readonly IRentalService _service;

    public RentalsController(IRentalService service)
    {
        _service = service;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Rental>> GetByIdAsync([FromRoute] int id)
    {
        Rental? rental = await _service.GetByIdAsync(id);

        if (rental is Rental) return Ok(rental);

        return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rental>>> GetAllAsync()
    {
        List<Rental> rentals = await _service.GetAllAsync();
        return Ok(rentals);
    }

    [HttpPost]
    public async Task<ActionResult<Rental>> CreateAsync([FromBody] RentalRequestDTO rentalRequestDto)
    {
        Rental rental = await _service.CreateAsync(rentalRequestDto);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = rental.Id }, rental);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] RentalRequestDTO rentalRequestDto)
    {
        bool isUpdated = await _service.UpdateAsync(id, rentalRequestDto);

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