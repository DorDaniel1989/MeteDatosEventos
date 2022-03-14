using MeteDatosEventos.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Facades
{
    interface GestionVista
    {
        void mostrarUsuarios(List<Usuario> listaObjetos);
        void mostrarInscripciones(List<Inscripcion> listaObjetos);
        void mostrarCategorias(List<Categoria> listaObjetos);
        void mostrarEventos(List<Evento> listaObjetos);
        void mostrarComentarios(List<Comentario> listaObjetos);
        void mostrarNumComentariosPorCategoria(IEnumerable<dynamic> listaObjetos);
        void mostrarNumComentariosDeUnEvento(String data);
        void mostrarNumComentariosDeUnUsuario(String data);
        void mostrarMenuPrincipal();
        void imprimirRegistros(IEnumerable registros);
    }
}
