using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeteDatosEventos.Models
{
    public class Usuario
    {
        //CAMPOS
       
        public string usuarioId { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellido {get;set;}


        
        public override string ToString()
        {
           return String.Format("   |{0,10}    |{1,10}     |{2,55}     |{3,15}     |{4,20}     |", usuarioId, password, email, nombre, apellido);
           
        }
       

    }
}
