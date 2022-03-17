using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Models
{
     public class Localizacion
    {
        public string LocalizacionId { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }


       

        public override string ToString()
        {
            return String.Format("   |{0,60}     | {1,30}     |{2,30}     |", LocalizacionId, latitud, longitud);

        }
    }
}
