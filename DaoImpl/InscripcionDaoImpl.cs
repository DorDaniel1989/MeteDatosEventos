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
    class InscripcionDaoImpl : InscripcionDao
    {
        private List<Inscripcion> inscripciones;
        ApiContext conexionBD;

        public InscripcionDaoImpl(ApiContext conexionBD)
        {
            this.conexionBD = conexionBD;
        }
        //Falta inyeccion de dependencia
        public List<Inscripcion> getInscripciones()
        {
            inscripciones = conexionBD.Inscripciones.ToList();
            return inscripciones;
        }
        public Inscripcion getInscripcion()
        {
            throw new NotImplementedException();
        }

        
    }
}
