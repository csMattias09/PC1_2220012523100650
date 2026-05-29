using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Library.Core.DTOs;
using TallerMecanico.Library.Core.Interfaces;

namespace PC1_22200133_24100302.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenServicioController : ControllerBase
{
    private readonly IOrdenServicioService _service;

    public OrdenServicioController(IOrdenServicioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ordenes = await _service.GetAllAsync();
        return Ok(ordenes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var orden = await _service.GetByIdAsync(id);
        if (orden == null) return NotFound();
        return Ok(orden);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrdenServicioDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateOrdenServicioDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
