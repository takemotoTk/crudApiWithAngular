using System;
using System.ComponentModel.DataAnnotations;

namespace GolAirlines.Entities
{
    public class Airplane
    {
        [Key]
        [Required]
        public int CodigoDoAviao { get; set; }

        [Required]
        public ModeloAirplaneType Modelo { get; set; }

        [Required]
        public int QuantidadePassageiros { get; set; }

        public DateTime DataDeCriacaoDoRegistro
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
