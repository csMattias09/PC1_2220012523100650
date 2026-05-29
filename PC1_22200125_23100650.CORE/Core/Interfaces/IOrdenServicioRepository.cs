using TallerMecanico.Library.Core.Entities;

namespace TallerMecanico.Library.Core.Interfaces;

public interface IOrdenServicioRepository
{
    Task<IEnumerable<OrdenServicio>> GetAllAsync();
    Task<OrdenServicio?> GetByIdAsync(int id);
    Task<OrdenServicio> CreateAsync(OrdenServicio ordenServicio);
    Task<OrdenServicio?> UpdateAsync(int id, OrdenServicio ordenServicio);
    Task<bool> DeleteAsync(int id);
}
