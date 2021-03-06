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
    class EventoDaoImpl : EventoDao
    {
        private List<Evento> eventos;
        private Evento evento;
        ApiContext conexionBD;

        //Inyeccion de dependencia
        public EventoDaoImpl(ApiContext conexionBD)
        {
            this.conexionBD = conexionBD;
          
        }

        public List<Evento> getEventos()
        {
            eventos = conexionBD.Eventos.ToList();
            return eventos;
        }
        public Evento getEvento(string id)
        {
            throw new NotImplementedException();
        }

        public void saveEvento(Evento evento)
        {
            throw new NotImplementedException();
        }

        public void deleteEvento(string id)
        {
            throw new NotImplementedException();
        }

        public void updateEvento(Evento evento)
        {
            throw new NotImplementedException();
        }
    }
}
