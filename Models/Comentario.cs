using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeteDatosEventos.Models
{
    public class Comentario
    {
        //CAMPOS
        public int ComentarioId { get; set; }
        public string EventoId { get; set; }
        public string ComentarioTxt { get; set; }
        public string CategoriaId { get; set; }
        public string UsuarioId { get; set; }
        public string FechaComentario { get; set; }
        
        public override string ToString()
        {
            return String.Format("   |{0,15}   |{1,20}   |{2,20}   |{3,55}   |{4,60}    |", UsuarioId, FechaComentario, CategoriaId, EventoId, ComentarioTxt);
          
        }
    }
}

