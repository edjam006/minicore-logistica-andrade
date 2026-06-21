using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinicoreLogisticaAndrade.Models
{
    [Table("zonas")]
    public class Zonas
    {
        [Key]
        [Column("id_zona")]
        public int IdZona { get; set; }

        [Required]
        [Column("nombre_zona")]
        public string NombreZona { get; set; } = string.Empty;

        [Required]
        [Column("tarifa_por_kg")]
        public decimal TarifaPorKg { get; set; }

        public ICollection<Envios> Envios { get; set; } = new List<Envios>();
    }
}
