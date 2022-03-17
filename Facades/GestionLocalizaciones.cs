using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Facades
{
     interface GestionLocalizaciones
    {
        List<Localizacion> getLocalizaciones();
    }
}
