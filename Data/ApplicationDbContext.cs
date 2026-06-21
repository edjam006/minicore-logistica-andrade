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

            // Seed Data - Zonas
            modelBuilder.Entity<Zonas>().HasData(
                new Zonas { IdZona = 1, NombreZona = "Norte", TarifaPorKg = 1.50m },
                new Zonas { IdZona = 2, NombreZona = "Sur", TarifaPorKg = 2.00m },
                new Zonas { IdZona = 3, NombreZona = "Centro", TarifaPorKg = 1.25m }
            );

            // Seed Data - Repartidores
            modelBuilder.Entity<Repartidor>().HasData(
                new Repartidor { IdRepartidor = 1, Nombre = "Andrés", Email = "andres@logistica.com" },
                new Repartidor { IdRepartidor = 2, Nombre = "Camila", Email = "camila@logistica.com" },
                new Repartidor { IdRepartidor = 3, Nombre = "Luis", Email = "luis@logistica.com" }
            );

            // Seed Data - Envios
            modelBuilder.Entity<Envios>().HasData(
                new Envios { IdEnvio = 1, IdRepartidor = 1, IdZona = 1, PesoKg = 10m, FechaEnvio = new DateTime(2025, 5, 5) },
                new Envios { IdEnvio = 2, IdRepartidor = 1, IdZona = 1, PesoKg = 22m, FechaEnvio = new DateTime(2025, 5, 12) },
                new Envios { IdEnvio = 3, IdRepartidor = 2, IdZona = 2, PesoKg = 18m, FechaEnvio = new DateTime(2025, 5, 10) },
                new Envios { IdEnvio = 4, IdRepartidor = 1, IdZona = 3, PesoKg = 15m, FechaEnvio = new DateTime(2025, 6, 1) }
            );
        }
    }
}
