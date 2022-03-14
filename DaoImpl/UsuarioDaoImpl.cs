using MeteDatosEventos.Daos;
using MeteDatosEventos.Data;
using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.DaoImpl
{
    class UsuarioDaoImpl : UsuarioDao
    {
        private List<Usuario> usuarios;
        ApiContext conexionBD;

        //Inyeccion de dependencia 
        public UsuarioDaoImpl(ApiContext conexionBD)
        {
            this.conexionBD = conexionBD;
        }

        public List<Usuario> getUsuarios()
        {
            usuarios = conexionBD.Usuarios.ToList();
            return usuarios;
        }

        public Usuario getUsuario(string id)
        {
            throw new NotImplementedException();
        }

       
       
    }
}
