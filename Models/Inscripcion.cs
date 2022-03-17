using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeteDatosEventos.Models
{
    public class Inscripcion
    {
    
        public int InscripcionId { get; set; }
        public string UsuarioId { get; set; }
        public string EventoId { get; set; }

        public int Valoracion { get; set; }


        public override string ToString()
        {
            return String.Format("   |{0,15}   |{1,14}   |{2,55}   |{3,15}   |", InscripcionId, UsuarioId, EventoId , Valoracion);
           
        }
    }
}
