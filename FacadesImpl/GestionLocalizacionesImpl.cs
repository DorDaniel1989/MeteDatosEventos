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
    class GestionLocalizacionesImpl : GestionLocalizaciones
    {
        LocalizacionDao localizacionDao;
        List<Localizacion> localizaciones;

        //Inyeccion de dependencias
        public GestionLocalizacionesImpl(ApiContext conexionBD)
        {
            localizacionDao = new LocalizacionDaoImpl(conexionBD);

        }

        public List<Localizacion> getLocalizaciones()
        {
            localizaciones = localizacionDao.getLocalizaciones();
            return localizaciones;
        }
    }
}

