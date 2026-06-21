using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinicoreLogisticaAndrade.Models
{
    [Table("envios")]
    public class Envios
    {
        [Key]
        [Column("id_envio")]
        public int IdEnvio { get; set; }

        [Required]
        [Column("id_repartidor")]
        public int IdRepartidor { get; set; }

        [Required]
        [Column("id_zona")]
        public int IdZona { get; set; }

        [Required]
        [Column("peso_kg")]
        public decimal PesoKg { get; set; }

        [Required]
        [Column("fecha_envio", TypeName = "date")]
        public DateTime FechaEnvio { get; set; }

        [ForeignKey("IdRepartidor")]
        public Repartidor Repartidor { get; set; } = null!;

        [ForeignKey("IdZona")]
        public Zonas Zonas { get; set; } = null!;
    }
}
