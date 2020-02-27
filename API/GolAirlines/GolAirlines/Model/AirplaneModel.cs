using GolAirlines.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolAirlines.Model
{
    public class AirplaneModel
    {
        public int CodigoDoAviao { get; set; }

        public ModeloAirplaneType Modelo { get; set; }

        public int QuantidadePassageiros { get; set; }


        public DateTime DataDeCriacaoDoRegistro
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public string DataRegistro
        {
            get
            {
                return this.DataDeCriacaoDoRegistro != null ? this.DataDeCriacaoDoRegistro.ToString("MM/dd/yyyy HH:mm") : "";
            }
        }
    }
}
