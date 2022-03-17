using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeteDatosEventos.Models
{
    public class Categoria
    {
        
       // public string categoriaId {get;set;}
        public string CategoriaId { get; set; }
        public string Descripcion_categoria { get; set; }
        public override string ToString()
        {
            return String.Format("   |{0,20}     |{1,80}     |", CategoriaId, Descripcion_categoria);
        }
    }
}
