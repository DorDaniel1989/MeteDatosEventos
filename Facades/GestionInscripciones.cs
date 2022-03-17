using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Facades
{
    interface GestionInscripciones
    {
        List<Inscripcion> getInscripciones();

        IEnumerable<dynamic> getValoracionMediaDeUsuariosAgrupados();
        IEnumerable<dynamic> getValoracionMediaDeEventosAgrupados();
        string getValoracionMediaDeUnUsuario();

        //Añadir funciones crud de inscripciones
    }
}
