using MeteDatosEventos.DaoImpl;
using MeteDatosEventos.Daos;
using MeteDatosEventos.Data;
using MeteDatosEventos.Facades;
using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.FacadesImpl
{
    class GestionUsuariosImpl : GestionUsuarios
    {
        //Instanciamos el objeto que se conectara a la base de datos y del que nos valdremos
        UsuarioDao usuarioDao ;
     
        public GestionUsuariosImpl(ApiContext conexionBD)
        {
            usuarioDao = new UsuarioDaoImpl(conexionBD);

        }
        

        public List<Usuario> getUsuarios()
        {
            return usuarioDao.getUsuarios();
        }

        //Mas metodos relacionados con los usuarios 
        //....
    }
}
