using Microsoft.EntityFrameworkCore;
using TallerMecanico.Library.Core.Entities;
using TallerMecanico.Library.Core.Interfaces;
using TallerMecanico.Library.Infrastructure.Data;

namespace TallerMecanico.Library.Infrastructure.Repositories;

public class OrdenServicioRepository : IOrdenServicioRepository
{
    private readonly TallerMecanicoContext _context;

    public OrdenServicioRepository(TallerMecanicoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrdenServicio>> GetAllAsync()
    {
        return await _context.OrdenServicios
            .Include(o => o.Vehiculo)
            .Include(o => o.TipoServicio)
            .ToListAsync();
    }

    public async Task<OrdenServicio?> GetByIdAsync(int id)
    {
        return await _context.OrdenServicios
            .Include(o => o.Vehiculo)
            .Include(o => o.TipoServicio)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<OrdenServicio> CreateAsync(OrdenServicio ordenServicio)
    {
        _context.OrdenServicios.Add(ordenServicio);
        await _context.SaveChangesAsync();
        return ordenServicio;
    }

    public async Task<OrdenServicio?> UpdateAsync(int id, OrdenServicio ordenServicio)
    {
        var existing = await _context.OrdenServicios.FindAsync(id);
        if (existing == null) return null;

        existing.FechaIngreso = ordenServicio.FechaIngreso;
        existing.DescripcionProblema = ordenServicio.DescripcionProblema;
        existing.CostoEstimado = ordenServicio.CostoEstimado;
        existing.Estado = ordenServicio.Estado;
        existing.VehiculoId = ordenServicio.VehiculoId;
        existing.TipoServicioId = ordenServicio.TipoServicioId;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var orden = await _context.OrdenServicios.FindAsync(id);
        if (orden == null) return false;

        _context.OrdenServicios.Remove(orden);
        await _context.SaveChangesAsync();
        return true;
    }
}
