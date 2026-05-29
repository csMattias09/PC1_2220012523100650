using Microsoft.EntityFrameworkCore;
using TallerMecanico.Library.Core.Entities;

namespace TallerMecanico.Library.Infrastructure.Data;

public partial class TallerMecanicoContext : DbContext
{
    public TallerMecanicoContext() { }

    public TallerMecanicoContext(DbContextOptions<TallerMecanicoContext> options)
        : base(options) { }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Vehiculo> Vehiculos { get; set; }
    public virtual DbSet<OrdenServicio> OrdenServicios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PrecioBase).HasColumnType("decimal(10,2)");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Paterno).HasMaxLength(50);
            entity.Property(e => e.Materno).HasMaxLength(50);
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Placa).HasMaxLength(10);
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.HasOne(e => e.Cliente)
                .WithMany(c => c.Vehiculos)
                .HasForeignKey(e => e.ClienteId)
                .HasConstraintName("FK_Vehiculo_Cliente");
        });

        modelBuilder.Entity<OrdenServicio>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DescripcionProblema).HasMaxLength(500);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.CostoEstimado).HasColumnType("decimal(10,2)");
            entity.HasOne(e => e.Vehiculo)
                .WithMany(v => v.OrdenServicios)
                .HasForeignKey(e => e.VehiculoId)
                .HasConstraintName("FK_OrdenServicio_Vehiculo");
            entity.HasOne(e => e.TipoServicio)
                .WithMany(t => t.OrdenServicios)
                .HasForeignKey(e => e.TipoServicioId)
                .HasConstraintName("FK_OrdenServicio_TipoServicio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
