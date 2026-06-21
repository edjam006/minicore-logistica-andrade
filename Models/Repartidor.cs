using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinicoreLogisticaAndrade.Models
{
    [Table("repartidor")]
    public class Repartidor
    {
        [Key]
        [Column("id_repartidor")]
        public int IdRepartidor { get; set; }

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("email")]
        public string? Email { get; set; }

        public ICollection<Envios> Envios { get; set; } = new List<Envios>();
    }
}
