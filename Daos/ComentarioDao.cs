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
        IEnumerable<dynamic> getNumDeComentariosUsuarioAgrupados();
        string getNumDeComentariosDeUnEvento();
        IEnumerable<dynamic> getNumDeComentariosEventosAgrupados();
        void añadirComentario();
        void deleteComentario(string comentarioId);
        void updateComentario(string comentario);
        
    }
}
