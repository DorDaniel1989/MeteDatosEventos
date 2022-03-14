using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Daos
{
    interface ComentarioDao
    {

       // Comentario getComentario(string id);
        List<Comentario> getComentarios();
        List<Comentario> getComentariosDeUsuario();
        List<Comentario> getComentariosDeEvento();
        IEnumerable<dynamic> getNumComentariosPorCategoria();
        string getNumDeComentariosUsuario();
        string getNumDeComentariosDeUnEvento();
        void añadirComentario();
        
    }
}
