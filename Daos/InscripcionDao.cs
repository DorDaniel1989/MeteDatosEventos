using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Daos
{
    interface InscripcionDao
    {
        Inscripcion getInscripcion();
        List<Inscripcion> getInscripciones();
        void saveInscripcion(Inscripcion inscripcion);
        void deleteInscripcion(Inscripcion inscripcion);
        void updateInscripcion(Inscripcion inscripcion);

        string getValoracionMediaDeUnUsuario();
        IEnumerable<dynamic> getValoracionMediaDeUsuariosAgrupados();

        string getValoracionMediaDeUnEvento();
        IEnumerable<dynamic> getValoracionMediaDeEventosAgrupados();
    }
}
