using MeteDatosEventos.DaoImpl;
using MeteDatosEventos.Daos;
using MeteDatosEventos.Data;
using MeteDatosEventos.Facades;
using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.FacadesImpl
{
    class GestionComentariosImpl : GestionComentarios
    {

        ComentarioDao comentarioDao ;

        //Inyeccion de dependencia
        public GestionComentariosImpl(ApiContext conexionDB)
        {
            comentarioDao = new ComentarioDaoImpl(conexionDB);
        }
        public void añadirComentario()
        {
            comentarioDao.añadirComentario();
        }

        public List<Comentario> getComentarios()
        {
           return comentarioDao.getComentarios();
        }

        public List<Comentario> getComentariosDeUnEvento()
        {
            return comentarioDao.getComentariosDeEvento();
        }

        public List<Comentario> getComentariosDeUnUsuario()
        {
            return comentarioDao.getComentariosDeUsuario();
        }

        public string getNumComentariosDeUnEvento()
        {
            return comentarioDao.getNumDeComentariosDeUnEvento();
        }

        public string getNumComentariosDeUnUsuario()
        {
            return comentarioDao.getNumDeComentariosUsuario();
        }

        public IEnumerable<dynamic> getNumComentariosPorCategoria()
        {
            return comentarioDao.getNumComentariosPorCategoria();
        }
    }
}
