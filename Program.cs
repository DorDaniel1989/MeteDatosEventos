using System;
using System.IO;
using MeteDatosEventos.Models;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using MeteDatosEventos.Data;
using System.Linq;
using MeteDatosEventos.Daos;
using MeteDatosEventos.DaoImpl;
using Colorful;
using Console = Colorful.Console;
using System.Drawing;
using MeteDatosEventos.Facades;
using MeteDatosEventos.FacadesImpl;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MeteDatosEventos
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "GOD MODE CONSOLE";
            string prompt =@"                 ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄        ▄▄       ▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄ 
                ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌      ▐░░▌     ▐░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌
                ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌     ▐░▌░▌   ▐░▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ 
                ▐░▌          ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌▐░▌ ▐░▌▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌          
                ▐░▌ ▄▄▄▄▄▄▄▄ ▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌ ▐░▐░▌ ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄ 
                ▐░▌▐░░░░░░░░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌  ▐░▌  ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌
                ▐░▌ ▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌   ▀   ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀▀▀ 
                ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌     ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌          
                ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌     ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄ 
                ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌      ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌
                 ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀        ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀   ▀▀▀▀▀▀▀▀▀▀▀";

            string footer = @" ";


            string[] opcionesMenu = new string[] { "CARGAR DATOS", "VER CATEGORIAS", "VER USUARIOS", "VER COMENTARIOS", "VER EVENTOS", "VER INSCRIPCIONES" +""
                , "VER LOCALIZACIONES", "NUMERO DE COMENTARIOS POR CATEGORIA","NUMERO DE COMENTARIOS POR EVENTO","NUMERO DE COMENTARIOS POR USUARIO" ,"NUMERO DE COMENTARIOS DE UN EVENTO", "NUMERO DE COMENTARIOS DE UN USUARIO", "VER COMENTARIOS DE UN USUARIO A ELEGIR", "VER COMENTARIOS DE UN EVENTO A ELEGIR","VER VALORACIONES MEDIAS POR USUARIOS","VER VALORACIONES MEDIAS POR EVENTO", "AÑADIR COMENTARIO A UN EVENTO", "SALIR" };


            ApiContext conexionBD = new ApiContext();


            ////INSTANCIAMOS LOS GESTORES CON SU DEPENDENCIA DE CONEXION
            GestionVista gestorVistas = new GestionVistaImpl();
            GestionArchivosLocales gestorArchivos = new GestionArchivosLocalesImpl();
            GestionUsuarios gestorUsuarios = new GestionUsuariosImpl(conexionBD);
            GestionEventos gestorEventos = new GestionEventosImpl(conexionBD);
            GestionCategorias gestorCategorias = new GestionCategoriasImpl(conexionBD);
            GestionComentarios gestorComentarios = new GestionComentariosImpl(conexionBD);
            GestionInscripciones gestorInscripciones = new GestionInscripcionesImpl(conexionBD);
            GestionLocalizaciones gestorLocalizaciones = new GestionLocalizacionesImpl(conexionBD);
            GestorMenus mainMenu = new GestorMenus(prompt, opcionesMenu, footer);




            var bucle = true;
            //INICIAMOS LA APLICACION
            while (bucle)
            {
                Console.Beep(700, 100);
                int indiceSeleccionado = mainMenu.Run();
                Console.Beep(600, 90);
                ejecutarOpcion(indiceSeleccionado);

            }

            Console.WriteAscii("HASTA LA VISTA");

            void ejecutarOpcion(int opcion)
            {

                switch (opcion)
                {

                    //case 0: gestorArchivos.insertarDatos(); return;  ACTUALIZAR LOS ARCHIVOS SQL A JSON, O CAMBIAR EL METODO PARA METER LOS DATOS
                    case 1:  gestorVistas.mostrarCategorias(gestorCategorias.getCategorias()); return;
                    case 2:  gestorVistas.mostrarUsuarios(gestorUsuarios.getUsuarios()); return;
                    case 3:  gestorVistas.mostrarComentarios(gestorComentarios.getComentarios()); return;
                    case 4:  gestorVistas.mostrarEventos(gestorEventos.getEventos()); return;
                    case 5:  gestorVistas.mostrarInscripciones(gestorInscripciones.getInscripciones()); return;
                    case 6:  gestorVistas.mostrarLocalizaciones(gestorLocalizaciones.getLocalizaciones()); return;
                    case 7:  gestorVistas.mostrarNumComentariosPorCategoria(gestorComentarios.getNumComentariosPorCategoria()); return;
                    case 8:  gestorVistas.mostrarNumComentariosPorEvento(gestorComentarios.getNumComentariosPorEvento()); return;
                    case 9:  gestorVistas.mostrarNumComentariosPorUsuario(gestorComentarios.getNumComentariosPorUsuario()); return;
                    case 10: gestorVistas.mostrarNumComentariosDeUnEvento(gestorComentarios.getNumComentariosDeUnEvento()); return;
                    case 11: gestorVistas.mostrarNumComentariosDeUnUsuario(gestorComentarios.getNumComentariosDeUnUsuario()); return;
                    case 12: gestorVistas.mostrarComentarios(gestorComentarios.getComentariosDeUnUsuario()); return;
                    case 13: gestorVistas.mostrarComentarios(gestorComentarios.getComentariosDeUnEvento()); return;
                    case 14: gestorVistas.mostrarValoracionMediaPorUsuario(gestorInscripciones.getValoracionMediaDeUsuariosAgrupados()); return;
                    case 15: gestorVistas.mostrarValoracionMediaPorEvento(gestorInscripciones.getValoracionMediaDeEventosAgrupados()); return;
                    case 16: gestorComentarios.añadirComentario(); return;
                    case 17: bucle = false; return;

                }
            }
        }
    }
}