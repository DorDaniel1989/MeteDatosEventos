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
    class GestionEventosImpl : GestionEventos
    {
        EventoDao eventoDao;
     
        //Inyeccion de dependencias
        public GestionEventosImpl(ApiContext conexionBD)
        {
            eventoDao = new EventoDaoImpl(conexionBD);
            
        }
        public List<Evento> getEventos()
        {
            return eventoDao.getEventos();
        }
    }
}
