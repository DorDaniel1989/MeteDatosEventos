using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Daos
{
    interface EventoDao
    {
        Evento getEvento(string id);
        List<Evento> getEventos();
        void saveEvento(Evento evento);
        void deleteEvento(string id);
        void updateEvento(Evento evento);

    }
}
