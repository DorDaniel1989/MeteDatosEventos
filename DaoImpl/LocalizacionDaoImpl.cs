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

    class LocalizacionDaoImpl : LocalizacionDao
    {
        ApiContext conexionBD;
        List<Localizacion> localizaciones;
        public LocalizacionDaoImpl(ApiContext conexionBD)
        {
            this.conexionBD = conexionBD;
        }

        public List<Localizacion> getLocalizaciones()
        {
            localizaciones = conexionBD.Localizaciones.ToList();
            return localizaciones; 
        }

        public void saveLocalizacion(Localizacion localizacion)
        {
            throw new NotImplementedException();
        }

        public void updateLocalizacion(string id)
        {
            throw new NotImplementedException();
        }

        public void deleteLocalizacion(string id)
        {
            throw new NotImplementedException();
        }
    }
}
