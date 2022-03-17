
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MeteDatosEventos.Models
{
    public class Evento
    {
    
        public string EventoId { get; set; }
        public string FechaInic { get; set; }
        public string FechaFin { get; set; }
        public string HoraInic { get; set; }
        public string HoraFin { get; set; }
        public string Descripcion { get; set; } 
        public string LocalizacionId { get; set; }
        public string CategoriaId { get; set; }
        public string ValoracionUsuarios { get; set; }
        public string Precio { get; set; }
        [NotMapped]
        public Blob Imagen { get; set; }

    public override string ToString()
        {
            return String.Format("   |{0,60}     | {1,18}     |{2,15}     |{3,15}     |{4,50}     |{5,15}     |", EventoId, CategoriaId, Precio, HoraInic, LocalizacionId, FechaInic);

        }
    }
}
