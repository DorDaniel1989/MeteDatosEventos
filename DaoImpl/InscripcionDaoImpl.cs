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
        IEnumerable<dynamic> listaDinamica;
        ApiContext conexionBD;

        public InscripcionDaoImpl(ApiContext conexionBD)
        {
            this.conexionBD = conexionBD;
        }
     
        public List<Inscripcion> getInscripciones()
        {
            inscripciones = conexionBD.Inscripciones.ToList();
            return inscripciones;
        }
     
        public Inscripcion getInscripcion()
        {
            throw new NotImplementedException();
        }

        public string getValoracionMediaDeUnUsuario()
        {
            var listaUsuarios = conexionBD.Usuarios.OrderBy(o => o.usuarioId).ToList();
            string resulPareseado = "";
            var i = 1;

            foreach (Usuario us in listaUsuarios)
            {
                Console.WriteLine(i + " -" + us.usuarioId);
                i++;
            }

            Console.WriteLine("Elige usuario");
            int opcion = Int32.Parse(Console.ReadLine());
            Console.Beep(600, 90);


            var resul = conexionBD.Inscripciones.GroupBy(g=>g.UsuarioId ).Select(s=> new
            {
               usuario = s.Key,
               valoracionMedia = s.Select(o=>o.Valoracion).Average()
            }).ToList();

            //Parseamos a string la lista anonima que devuelve la consulta
            try
            {
                resulPareseado = String.Format("   |{0,30}|{1,24}|", resul[0].usuario, resul[0].valoracionMedia);
            }
            catch (Exception ex)
            {

                resulPareseado = "       SIN   VALORACIONES  ";

            }



            return resulPareseado;
        }

        public IEnumerable<dynamic> getValoracionMediaDeUsuariosAgrupados()
        {
            listaDinamica = conexionBD.Inscripciones.GroupBy(g => g.UsuarioId).Select(s => new
            {
                usuario = s.Key,
                valoracionMedia = s.Select(o => o.Valoracion).Average()
            }).OrderByDescending(o=>o.valoracionMedia).ToList();

            return listaDinamica;
        }
     
        public string getValoracionMediaDeUnEvento()
        {
            
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> getValoracionMediaDeEventosAgrupados()
        {
            listaDinamica = conexionBD.Inscripciones.GroupBy(g => g.EventoId).Select(s => new
            {
                evento = s.Key,
                valoracionMedia = s.Select(o => o.Valoracion).Average()
            }).OrderByDescending(o => o.valoracionMedia).ToList();

            return listaDinamica;
        }

        public void saveInscripcion(Inscripcion inscripcion)
        {
            throw new NotImplementedException();
        }

        public void deleteInscripcion(Inscripcion inscripcion)
        {
            throw new NotImplementedException();
        }

        public void updateInscripcion(Inscripcion inscripcion)
        {
            throw new NotImplementedException();
        }
    }
}
