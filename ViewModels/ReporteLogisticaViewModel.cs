namespace MinicoreLogisticaAndrade.ViewModels
{
    public class ReporteRepartidorRow
    {
        public string NombreRepartidor { get; set; } = string.Empty;
        public int CantidadEnvios { get; set; }
        public decimal TotalKg { get; set; }
        public string ZonasOperadas { get; set; } = string.Empty;
        public decimal CostoTotal { get; set; }
    }

    public class ReporteLogisticaViewModel
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<ReporteRepartidorRow> Resultados { get; set; } = new List<ReporteRepartidorRow>();
    }
}
