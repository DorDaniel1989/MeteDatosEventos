using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Daos
{
     interface LocalizacionDao
    {
        List<Localizacion> getLocalizaciones();
        void saveLocalizacion(Localizacion localizacion);
        void deleteLocalizacion(string id);
        void updateLocalizacion(string id);
    }
}
