using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallerMecanico.Library.Core.Entities;
using TallerMecanico.Library.Infrastructure.Data;

namespace PC1_22200133_24100302.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipoServicioController : ControllerBase
{
    private readonly TallerMecanicoContext _context;

    public TipoServicioController(TallerMecanicoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var lista = await _context.TipoServicios.ToListAsync();
        return Ok(lista);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tipoServicio = await _context.TipoServicios.FindAsync(id);
        if (tipoServicio == null) return NotFound();
        return Ok(tipoServicio);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TipoServicio tipoServicio)
    {
        _context.TipoServicios.Add(tipoServicio);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = tipoServicio.Id }, tipoServicio);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TipoServicio tipoServicio)
    {
        var existing = await _context.TipoServicios.FindAsync(id);
        if (existing == null) return NotFound();

        existing.Nombre = tipoServicio.Nombre;
        existing.PrecioBase = tipoServicio.PrecioBase;

        await _context.SaveChangesAsync();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tipoServicio = await _context.TipoServicios.FindAsync(id);
        if (tipoServicio == null) return NotFound();

        _context.TipoServicios.Remove(tipoServicio);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
