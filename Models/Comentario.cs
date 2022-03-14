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
        public int comentarioId { get; set; }
        public string eventoId { get; set; }
        public string comentario { get; set; }
        public string categoriaId { get; set; }
        public string usuarioId { get; set; }
        public string fechaComentario { get; set; }
        
        public override string ToString()
        {
            return String.Format("   |{0,15}   |{1,20}   |{2,20}   |{3,55}   |{4,60}    |", usuarioId, fechaComentario, categoriaId , eventoId, comentario);
          
        }
    }
}

