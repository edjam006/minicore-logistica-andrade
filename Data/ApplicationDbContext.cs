using Microsoft.EntityFrameworkCore;
using MinicoreLogisticaAndrade.Models;

namespace MinicoreLogisticaAndrade.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Repartidor> Repartidores { get; set; }
        public DbSet<Zonas> Zonas { get; set; }
        public DbSet<Envios> Envios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Repartidor
            modelBuilder.Entity<Repartidor>(entity =>
            {
                entity.HasKey(e => e.IdRepartidor);
                entity.Property(e => e.IdRepartidor).ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired();
            });

            // Configuración de Zonas
            modelBuilder.Entity<Zonas>(entity =>
            {
                entity.HasKey(e => e.IdZona);
                entity.Property(e => e.IdZona).ValueGeneratedOnAdd();
                entity.Property(e => e.NombreZona).IsRequired();
                entity.Property(e => e.TarifaPorKg).HasPrecision(18, 2);
            });

            // Configuración de Envios
            modelBuilder.Entity<Envios>(entity =>
            {
                entity.HasKey(e => e.IdEnvio);
                entity.Property(e => e.IdEnvio).ValueGeneratedOnAdd();
                entity.Property(e => e.PesoKg).HasPrecision(18, 2);
                entity.Property(e => e.FechaEnvio).HasColumnType("date");

                // Relación Envios -> Repartidor (muchos a uno)
                entity.HasOne(e => e.Repartidor)
                      .WithMany(r => r.Envios)
                      .HasForeignKey(e => e.IdRepartidor)
                      .OnDelete(DeleteBehavior.Cascade);

                // Relación Envios -> Zonas (muchos a uno)
                entity.HasOne(e => e.Zonas)
                      .WithMany(z => z.Envios)
                      .HasForeignKey(e => e.IdZona)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
