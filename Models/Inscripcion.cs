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
    
        public int inscripcionId { get; set; }
        public string usuarioId { get; set; }
        public string eventoId { get; set; }
       // public int valoracion { get; set; }


        public override string ToString()
        {
            return String.Format("   |{0,15}   |{1,14}   |{2,55}   |", inscripcionId, usuarioId, eventoId);
           
        }
    }
}
