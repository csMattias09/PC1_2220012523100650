namespace TallerMecanico.Library.Core.DTOs;

public class OrdenServicioDto
{
    public int Id { get; set; }
    public DateTime FechaIngreso { get; set; }
    public string DescripcionProblema { get; set; } = string.Empty;
    public decimal CostoEstimado { get; set; }
    public string Estado { get; set; } = string.Empty;
    public int VehiculoId { get; set; }
    public int TipoServicioId { get; set; }
}
