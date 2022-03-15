using MeteDatosEventos.Facades;
using MeteDatosEventos.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Console = Colorful.Console;

namespace MeteDatosEventos.FacadesImpl
{
    class GestionVistaImpl : GestionVista
    {
        //CABECERAS DE LAS TABLAS QUE MOSTRAMOS POR PANTALLA
        string cabeceraUsuarios                       = String.Format("   |{0,10}    |{1,10}     |{2,55}     |{3,15}     |{4,20}     |", "USUARIO", "PASSWORD", "EMAIL", "NOMBRE", "APELLIDO");
        string cabeceraCategorias                     = String.Format("   |{0,20}     |{1,80}     |", "CATEGORIA", "DESRCIPCION" );
        string cabeceraComentarios                    = String.Format("   |{0,15}   |{1,20}   |{2,20}   |{3,55}   |{4,60}    |", "USUARIO", "FECHA", "CATEGORIA", "EVENTO", "COMENTARIO");
        string cabeceraNumComentariosPorCategoria     = String.Format("   |{0,25}   |{1,20}   |", "CATEGORIA", " Nº DE COMENTARIOS");
        string cabeceraCantidadDeComentariosDeUsuario = String.Format("   |{0,15}|{1,20}|", "USUARIO", " Nº DE COMENTARIOS");
        string cabeceraInscripciones                  = String.Format("   |{0,15}   |{1,14}   |{2,55}   |", " ID INSCRIPCION", "USUARIO", "EVENTO");
        string cabeceraEvento                         = String.Format("   |{0,15}     | {1,15}     |{2,40}     |{3,20}     |{4,55}     |{5,12}  |", "LUGAR", "HORA", "FECHA","CATEGORIA", "EVENTO","PRECIO");
        string cabeceraCantidadDeComentariosEnEvento  = String.Format("   |{0,30}|{1,24}|", "EVENTO", "CANTIDAD DE COMENTARIOS");
        string lineaBajaCabecera = "   |_____ ________________________________________________________________________________________________________________________________________________________________________________________|";
        string espacioMenu = "                                   ";
        string espacio = "               ";
        GestorMenus gestorMenus ;
        //METODOS
        public void mostrarMenuPrincipal()
        {
            Console.Clear();
            //Valores de las opciones del menu
            string[] opcionesMenu = new string[] { "CARGAR DATOS", "VER CATEGORIAS", "VER USUARIOS", "VER COMENTARIOS", "VER EVENTOS", "VER INSCRIPCIONES", "NUMERO DE COMENTARIOS POR CATEGORIA", "NUMERO DE COMENTARIOS DE UN EVENTO", "NUMERO DE COMENTARIOS DE UN USUARIO", "VER COMENTARIOS DE UN USUARIO A ELEGIR", "VER COMENTARIOS DE UN EVENTO A ELEGIR", "AÑADIR COMENTARIO A UN EVENTO", "SALIR" };
           
           
            //Recorremos los valores del array para imprimir el menu principal
            Console.WriteAscii("******   MODO DIOS   ******", Color.BlueViolet);
            for (int i = 0; i < opcionesMenu.Count(); i++)
            {

                Console.Write(espacioMenu +i + " - ", Color.GreenYellow);
                Console.Write(opcionesMenu[i], Color.Gold);
                Console.WriteLine("");
                Console.WriteLine("");
            }

            Console.Write("Introduce una opcion y pusa enter  =>" ,Color.GreenYellow);

        }

        public void mostrarUsuarios(List<Usuario> listaObjetos)
        {
            Console.Clear();                                        //Limpia la consola
            Console.WriteAscii(espacio+"Usuarios", Color.Yellow);   //Titulo centrado de la tabla
            Console.WriteLine(cabeceraUsuarios, Color.Goldenrod);   //Cabecera de la tabla
            Console.WriteLine(lineaBajaCabecera, Color.Goldenrod);  //Linea  baja de separacion de la cabecera
            imprimirRegistros(listaObjetos);                        //imprime el resto de registros de la lista
          
        }

        public void mostrarCategorias(List<Categoria> listaObjetos)
        {
            Console.Clear();
            Console.WriteAscii(espacio+"Categorias" , Color.Yellow);
            Console.WriteLine(cabeceraCategorias , Color.Goldenrod);
            Console.WriteLine(lineaBajaCabecera, Color.Goldenrod);
            imprimirRegistros(listaObjetos);
         
        }
        
        public void mostrarComentarios(List<Comentario> listaObjetos)
        {

            Console.Clear();
            Console.WriteAscii(espacio+"Comentarios", Color.Yellow);
            Console.WriteLine(cabeceraComentarios, Color.Goldenrod);
            Console.WriteLine(lineaBajaCabecera, Color.Goldenrod);
            imprimirRegistros(listaObjetos);
           
        }

        public void mostrarInscripciones(List<Inscripcion> listaObjetos)
        {
            Console.Clear();
            Console.WriteAscii(espacio+"Inscripciones", Color.Yellow);
            Console.WriteLine(cabeceraInscripciones, Color.Goldenrod);
            Console.WriteLine(lineaBajaCabecera, Color.Goldenrod);
            imprimirRegistros(listaObjetos);
        }

        public void mostrarEventos(List<Evento> listaObjetos)
        {
            Console.Clear();
            Console.WriteAscii(espacio+"Eventos", Color.Yellow);
            Console.WriteLine(cabeceraEvento, Color.Goldenrod);
            Console.WriteLine(lineaBajaCabecera, Color.Goldenrod);
            imprimirRegistros(listaObjetos);
            
        }

        public void mostrarNumComentariosPorCategoria(IEnumerable<dynamic> listaObjetos)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(cabeceraNumComentariosPorCategoria , Color.Goldenrod);
            Console.WriteLine(lineaBajaCabecera, Color.Goldenrod);
            foreach (var objeto in listaObjetos)
            {
                Console.WriteLine("   " + "|                                                                                                                                                                                                   |", Color.GreenYellow);
                var registro = String.Format("   |{0,25}   |{1,20}   |", objeto.categoria , objeto.cantidadComentarios);
                Console.WriteLine(registro , Color.GreenYellow);
                Console.WriteLine(lineaBajaCabecera, Color.GreenYellow);
            }
            Console.WriteLine();
            Console.WriteLine("Pulsa enter para regresar al menu principal ");
            Console.ReadLine();
        }

        public void mostrarNumComentariosDeUnEvento(string data)
        {
            Console.Clear();
            Console.WriteLine(cabeceraCantidadDeComentariosEnEvento, Color.Goldenrod);
            Console.WriteLine(lineaBajaCabecera, Color.Goldenrod);
            Console.WriteLine(data , Color.GreenYellow);
            Console.ReadLine();
        }

        public void mostrarNumComentariosDeUnUsuario(string data)
        {
            Console.Clear();
            Console.WriteLine(cabeceraCantidadDeComentariosDeUsuario, Color.Goldenrod);
            Console.WriteLine(lineaBajaCabecera, Color.Goldenrod);
            Console.WriteLine(data , Color.GreenYellow);
            Console.ReadLine();
        }

        public void imprimirRegistros(IEnumerable registros)
        {
            foreach (var objeto in registros)
            {  
                //Console.WriteLine("   " + "|                                                                                                                                                                                                   |", Color.GreenYellow);
                Console.WriteLine(objeto.ToString() ,Color.GreenYellow);
                Console.WriteLine(lineaBajaCabecera, Color.GreenYellow);
            }
            Console.WriteLine();
            Console.WriteLine("Pulsa enter para regresar al menu principal ");
            Console.ReadLine();
        }
    }
}
