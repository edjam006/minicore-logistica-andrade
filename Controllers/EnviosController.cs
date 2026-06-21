using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinicoreLogisticaAndrade.Data;
using MinicoreLogisticaAndrade.ViewModels;

namespace MinicoreLogisticaAndrade.Controllers
{
    public class EnviosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnviosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Envios/Reporte
        public IActionResult Reporte()
        {
            var viewModel = new ReporteLogisticaViewModel
            {
                FechaInicio = new DateTime(2025, 5, 1),
                FechaFin = new DateTime(2025, 5, 31)
            };
            return View(viewModel);
        }

        // POST: Envios/Reporte
        [HttpPost]
        public IActionResult Reporte(ReporteLogisticaViewModel viewModel)
        {
            // Obtener todos los repartidores para incluir los que tienen 0 envíos
            var todosRepartidores = _context.Repartidores.ToList();

            // Consulta LINQ: filtrar envíos por rango inclusivo de fechas,
            // incluir navegación a Repartidor y Zona, agrupar por Repartidor
            var enviosEnRango = _context.Envios
                .Include(e => e.Repartidor)
                .Include(e => e.Zonas)
                .Where(e => e.FechaEnvio >= viewModel.FechaInicio
                         && e.FechaEnvio <= viewModel.FechaFin)
                .ToList();

            // Agrupar por repartidor y calcular los totales
            var enviosAgrupados = enviosEnRango
                .GroupBy(e => new { e.IdRepartidor, e.Repartidor.Nombre })
                .Select(g => new ReporteRepartidorRow
                {
                    NombreRepartidor = g.Key.Nombre,
                    CantidadEnvios = g.Count(),
                    TotalKg = g.Sum(e => e.PesoKg),
                    ZonasOperadas = string.Join(", ", g.Select(e => e.Zonas.NombreZona).Distinct()),
                    CostoTotal = g.Sum(e => e.PesoKg * e.Zonas.TarifaPorKg)
                })
                .ToList();

            // Incluir repartidores con 0 envíos en el rango
            var repartidoresConEnvios = enviosAgrupados
                .Select(r => r.NombreRepartidor)
                .ToHashSet();

            var repartidoresSinEnvios = todosRepartidores
                .Where(r => !repartidoresConEnvios.Contains(r.Nombre))
                .Select(r => new ReporteRepartidorRow
                {
                    NombreRepartidor = r.Nombre,
                    CantidadEnvios = 0,
                    TotalKg = 0,
                    ZonasOperadas = "No aplica",
                    CostoTotal = 0.00m
                })
                .ToList();

            viewModel.Resultados = enviosAgrupados
                .Concat(repartidoresSinEnvios)
                .OrderBy(r => r.NombreRepartidor)
                .ToList();

            return View(viewModel);
        }
    }
}
