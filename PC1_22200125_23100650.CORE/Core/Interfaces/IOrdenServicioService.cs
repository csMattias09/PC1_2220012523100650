using TallerMecanico.Library.Core.DTOs;

namespace TallerMecanico.Library.Core.Interfaces;

public interface IOrdenServicioService
{
    Task<IEnumerable<OrdenServicioDto>> GetAllAsync();
    Task<OrdenServicioDto?> GetByIdAsync(int id);
    Task<OrdenServicioDto> CreateAsync(CreateOrdenServicioDto dto);
    Task<OrdenServicioDto?> UpdateAsync(int id, CreateOrdenServicioDto dto);
    Task<bool> DeleteAsync(int id);
}
