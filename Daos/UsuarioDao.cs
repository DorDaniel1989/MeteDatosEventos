using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Daos
{
    interface UsuarioDao
    {
       
        List<Usuario> getUsuarios();
        Usuario getUsuario(string id);
        void saveUsuario(Usuario usuario);
        void deleteUsuario(string id);
        void updateUsuario(Usuario usuario);

    }
}
