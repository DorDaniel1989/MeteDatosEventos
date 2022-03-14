
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeteDatosEventos.Models
{
    public class Evento
    {
    
        public string eventoId { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string lugar { get; set; }
        public string descripcion { get; set; } //No la muestro por pantalla
        public string precio { get; set; }
        public string categoriaId { get; set; }

        public override string ToString()
        {
            return String.Format("   |{0,15}     | {1,15}     |{2,40}     |{3,20}     |{4,55}     |{5,12}  |", lugar, hora, fecha,categoriaId , eventoId , precio);

        }

    }
}
