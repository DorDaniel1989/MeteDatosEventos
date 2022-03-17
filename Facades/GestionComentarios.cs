using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Facades
{
    interface GestionComentarios
    {
        List<Comentario> getComentarios();
        IEnumerable<dynamic> getNumComentariosPorCategoria();
        List<Comentario> getComentariosDeUnUsuario();

        List<Comentario> getComentariosDeUnEvento();
        string getNumComentariosDeUnEvento();
        IEnumerable<dynamic> getNumComentariosPorUsuario();
        string getNumComentariosDeUnUsuario();
        IEnumerable<dynamic> getNumComentariosPorEvento();
        void añadirComentario();


        // Añadir borrar comentario y actualizar comentario
    }
}
