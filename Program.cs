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

namespace MeteDatosEventos
{
    class Program
    {
        static void Main(string[] args)
        {


string prompt =@"▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄        ▄▄       ▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄ 
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
            string[] opcionesMenu = new string[] { "CARGAR DATOS", "VER CATEGORIAS", "VER USUARIOS", "VER COMENTARIOS", "VER EVENTOS", "VER INSCRIPCIONES", "NUMERO DE COMENTARIOS POR CATEGORIA", "NUMERO DE COMENTARIOS DE UN EVENTO", "NUMERO DE COMENTARIOS DE UN USUARIO", "VER COMENTARIOS DE UN USUARIO A ELEGIR", "VER COMENTARIOS DE UN EVENTO A ELEGIR", "AÑADIR COMENTARIO A UN EVENTO", "SALIR" };
      

         //   ConsoleKeyInfo teclaPresionada = Console.ReadKey();

            //if (teclaPresionada.Key == ConsoleKey.Enter)
            //{
            //    Console.WriteLine("Has presionado ENTER");
            //}
            //else if (teclaPresionada.Key == ConsoleKey.UpArrow)
            //{
            //    Console.WriteLine("Has presionado UP ARROW");
            //}
            //else
            //{
            //    Console.WriteLine("Has presionado otra tecla");

            //}

            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey(true);



            ApiContext conexionBD = new ApiContext();


            //INSTANCIAMOS LOS GESTORES CON SU DEPENDENCIA DE CONEXION
            GestionVista gestorVistas = new GestionVistaImpl();
            GestionArchivosLocales gestorArchivos = new GestionArchivosLocalesImpl();
            GestionUsuarios gestorUsuarios = new GestionUsuariosImpl(conexionBD);
            GestionEventos gestorEventos = new GestionEventosImpl(conexionBD);
            GestionCategorias gestorCategorias = new GestionCategoriasImpl(conexionBD);
            GestionComentarios gestorComentarios = new GestionComentariosImpl(conexionBD);
            GestionInscripciones gestorInscripciones = new GestionInscripcionesImpl(conexionBD);

            GestorMenus mainMenu = new GestorMenus(prompt, opcionesMenu);


            string[] flameo = new string[] { "OPERACION NO PERMITIDA", "QUE NO PUEDES HACER ESO ", "PERO A TI QUE TE PASA, METE UN NUMERO", "METE UN NUMERO IMBECIL", "ESTAS PONIENDO A PRUEBA MI PACIENCIA...", "HARE COMO SI FUERAS RETRASADO Y VOLVERE A EMPEZAR..¿VALE?" };
            int i = 0; // indice para array de flameo
            var bucle = true;
            //INICIAMOS LA APLICACION


            while (bucle)
            {
                int indiceSeleccionado = mainMenu.Run();
                ejecutarOpcion(indiceSeleccionado);

            }

      



            Console.WriteAscii("HASTA LA VISTA");

            void ejecutarOpcion(int opcion)
            {
                if (opcion > 12)
                {
                    Console.WriteLine("DE MOMENTO HAY TANTAS OPCIONES", Color.Red);
                    Console.ReadLine();
                    return;
                }
                switch (opcion)
                {
                    case 0: gestorArchivos.insertarDatos(); return;
                    case 1: gestorVistas.mostrarCategorias(gestorCategorias.getCategorias()); return;
                    case 2: gestorVistas.mostrarUsuarios(gestorUsuarios.getUsuarios()); return;
                    case 3: gestorVistas.mostrarComentarios(gestorComentarios.getComentarios()); return;
                    case 4: gestorVistas.mostrarEventos(gestorEventos.getEventos()); return;
                    case 5: gestorVistas.mostrarInscripciones(gestorInscripciones.getInscripciones()); return;
                    case 6: gestorVistas.mostrarNumComentariosPorCategoria(gestorComentarios.getNumComentariosPorCategoria()); return;
                    case 7: gestorVistas.mostrarNumComentariosDeUnEvento(gestorComentarios.getNumComentariosDeUnEvento()); return;
                    case 8: gestorVistas.mostrarNumComentariosDeUnUsuario(gestorComentarios.getNumComentariosDeUnUsuario()); return;
                    case 9: gestorVistas.mostrarComentarios(gestorComentarios.getComentariosDeUnUsuario()); return;
                    case 10: gestorVistas.mostrarComentarios(gestorComentarios.getComentariosDeUnEvento()); return;
                    case 11: gestorComentarios.añadirComentario(); return;
                    case 12: bucle = false; return;


                }

            }

        }
    }
}