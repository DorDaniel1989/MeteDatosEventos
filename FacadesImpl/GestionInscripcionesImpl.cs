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
    class GestionInscripcionesImpl : GestionInscripciones
    {
        InscripcionDao inscripcionDao;
        
        public GestionInscripcionesImpl(ApiContext conexionDB)
        {
            inscripcionDao = new InscripcionDaoImpl(conexionDB);
        }
        public List<Inscripcion> getInscripciones()
        {
            return inscripcionDao.getInscripciones();
        }

        public IEnumerable<dynamic> getValoracionMediaDeEventosAgrupados()
        {
            return inscripcionDao.getValoracionMediaDeEventosAgrupados();
        }

        public string getValoracionMediaDeUnUsuario()
        {
            return inscripcionDao.getValoracionMediaDeUnUsuario();
        }

        public IEnumerable<dynamic> getValoracionMediaDeUsuariosAgrupados()
        {
            return inscripcionDao.getValoracionMediaDeUsuariosAgrupados();
        }
    }
}
