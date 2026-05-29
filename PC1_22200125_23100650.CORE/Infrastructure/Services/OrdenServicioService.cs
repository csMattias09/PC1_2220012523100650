using TallerMecanico.Library.Core.DTOs;
using TallerMecanico.Library.Core.Entities;
using TallerMecanico.Library.Core.Interfaces;

namespace TallerMecanico.Library.Infrastructure.Services;

public class OrdenServicioService : IOrdenServicioService
{
    private readonly IOrdenServicioRepository _repository;

    public OrdenServicioService(IOrdenServicioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OrdenServicioDto>> GetAllAsync()
    {
        var ordenes = await _repository.GetAllAsync();
        return ordenes.Select(MapToDto);
    }

    public async Task<OrdenServicioDto?> GetByIdAsync(int id)
    {
        var orden = await _repository.GetByIdAsync(id);
        return orden == null ? null : MapToDto(orden);
    }

    public async Task<OrdenServicioDto> CreateAsync(CreateOrdenServicioDto dto)
    {
        var orden = MapToEntity(dto);
        var created = await _repository.CreateAsync(orden);
        return MapToDto(created);
    }

    public async Task<OrdenServicioDto?> UpdateAsync(int id, CreateOrdenServicioDto dto)
    {
        var orden = MapToEntity(dto);
        var updated = await _repository.UpdateAsync(id, orden);
        return updated == null ? null : MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    private static OrdenServicioDto MapToDto(OrdenServicio o) => new()
    {
        Id = o.Id,
        FechaIngreso = o.FechaIngreso,
        DescripcionProblema = o.DescripcionProblema,
        CostoEstimado = o.CostoEstimado,
        Estado = o.Estado,
        VehiculoId = o.VehiculoId,
        TipoServicioId = o.TipoServicioId
    };

    private static OrdenServicio MapToEntity(CreateOrdenServicioDto dto) => new()
    {
        FechaIngreso = dto.FechaIngreso,
        DescripcionProblema = dto.DescripcionProblema,
        CostoEstimado = dto.CostoEstimado,
        Estado = dto.Estado,
        VehiculoId = dto.VehiculoId,
        TipoServicioId = dto.TipoServicioId
    };
}
