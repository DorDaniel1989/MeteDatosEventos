using MeteDatosEventos.Daos;
using MeteDatosEventos.Data;
using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;


namespace MeteDatosEventos.DaoImpl
{
    class ComentarioDaoImpl : ComentarioDao
    {
        List<Comentario> comentarios;
        ApiContext conexionBD;

        //Inyeccion de dependencia
        public ComentarioDaoImpl(ApiContext conexionBD)
        {
            this.conexionBD = conexionBD;
        }

        public void añadirComentario()
        {
            Console.Clear();
            var listaUsuarios = conexionBD.Usuarios.OrderBy(o => o.usuarioId).ToList();
            var i = 1;

            Console.WriteAscii("USUARIOS" , Color.LightGoldenrodYellow);
            foreach (Usuario us in listaUsuarios)
            {
                Console.WriteLine(i + " -" + us.usuarioId);
                i++;
            }

            Console.WriteLine("Elige usuario" ,Color.GreenYellow);
            string opcionUsuario = Console.ReadLine();


            Console.Clear();
            //MOSTRAMOS LAS CATEGORIAS POR PANTALLA
            Console.WriteAscii("CATEGORIAS", Color.LightGoldenrodYellow);
            var listaCategorias = conexionBD.Categorias.OrderBy(o => o.categoriaId).ToList();
            var k = 1;

            foreach (Categoria cat in listaCategorias)
            {
                Console.WriteLine(k + " -" + cat.categoriaId);
                k++;
            }

            Console.WriteLine("Elige categoria", Color.GreenYellow);
            string opcionCategoria = Console.ReadLine();
            Console.Clear();
            //MOSTRAMOS LOS EVENTOS FILTRADOS POR CATEGORIAS
            Console.WriteAscii("EVENTOS", Color.LightGoldenrodYellow);
              
            var listaEventos = conexionBD.Eventos.OrderBy(o => o.eventoId).Where(w=>w.categoriaId==listaCategorias[Int32.Parse(opcionCategoria) -1].categoriaId).ToList();
            var x = 1;

            foreach (Evento ev in listaEventos)
            {
                Console.WriteLine(x + " -" + ev.eventoId);
                x++;
            }

            Console.WriteLine("Elige evento en el que comentar" , Color.GreenYellow);
            string opcionEvento = Console.ReadLine();
            Console.WriteLine("Introduce el comentario");
            string comentarioTxt = Console.ReadLine();
            Comentario comentario= new Comentario();
             
            comentario.usuarioId = listaUsuarios[Int32.Parse(opcionUsuario) - 1 ].usuarioId;
            comentario.eventoId = listaEventos[Int32.Parse(opcionEvento) - 1 ].eventoId;
            comentario.comentario = comentarioTxt;
            comentario.fechaComentario = "Hoy";
            comentario.categoriaId = listaCategorias[Int32.Parse(opcionCategoria) - 1].categoriaId;

            try
            {
                conexionBD.Comentarios.Add(comentario);
                conexionBD.SaveChanges();
                Console.WriteLine("Comentario introducido con exito" , Color.GreenYellow);
                Console.WriteLine(comentario);
               
                
            }
            catch(Exception e)
            {
                Console.WriteLine(" Ha ocurrido algun error " ,Color.Red);

            }
            Console.WriteLine("Presiona la tecla enter para volver al menu principal");
            Console.ReadLine();




        }
        //Investigar sobre como devolver una lista de tipo anonimo mejor que un string.
        public string getNumDeComentariosDeUnEvento()
        {

            var listaEventos = conexionBD.Eventos.OrderBy(o => o.eventoId).ToList();
            var i = 1;

            foreach (Evento eve in listaEventos)
            {
                Console.WriteLine(i + " -" + eve.eventoId);
                i++;
            }

            Console.WriteLine("Elige el evento");
            string opcion = Console.ReadLine();

            var resul = conexionBD.Comentarios.GroupBy(g => g.eventoId).Select(s => new
            {
                evento = s.Key,
                cantidad = s.Count().ToString()

            }).Where(w => w.evento == listaEventos[Int32.Parse(opcion) -1].eventoId).ToList();

            //Parseamos a string la lista anonima que devuelve la consulta
            string resulPareseado="";
            try
            {
                resulPareseado= String.Format("|{0,30}|{1,24}|", resul[0].evento, resul[0].cantidad) ;
            }
            catch(Exception e)
            {
                Console.WriteLine("No hay comentarios para mostrar",Color.Red);
            }

            return resulPareseado;
            


        }

        public string  getNumDeComentariosUsuario()
        {
            
                var listaUsuarios = conexionBD.Usuarios.OrderBy(o => o.usuarioId).ToList();
                var i = 1;

                foreach (Usuario us in listaUsuarios)
                {
                    Console.WriteLine(i + " -" + us.usuarioId);
                    i++;
                }

                Console.WriteLine("Elige usuario");
                string opcion = Console.ReadLine();


                var resul = conexionBD.Comentarios.GroupBy(g => g.usuarioId).Select(s => new
                {
                    usuario = s.Key,
                    cantidad = s.Count().ToString()

                }).Where(w => w.usuario == listaUsuarios[Int32.Parse(opcion) - 1].usuarioId).ToList();

               //Parseamos a string la lista anonima que devuelve la consulta
                var resulPareseado = resul[0].usuario + "  " + resul[0].cantidad;
                return resulPareseado;
            


        }

        public List<Comentario> getComentarios()
        {
            comentarios = conexionBD.Comentarios.ToList();
            return comentarios;
        }

        public List<Comentario> getComentariosDeEvento()
        {
            var listaEventos = conexionBD.Eventos.OrderBy(o => o.eventoId).ToList();
            var i = 1;

            foreach (Evento eve in listaEventos)
            {
                Console.Write((i + " -" ) , Color.GreenYellow);
                Console.Write(eve.eventoId , Color.Orange);
                Console.WriteLine();
                i++;
            }

            Console.WriteLine("Elige un evento" , Color.GreenYellow);
            string evento = Console.ReadLine();

            //Console.WriteLine(Int32.Parse(evento));
            //Console.WriteLine(listaEventos[Int32.Parse(evento)-1].eventoId);

            var resul = conexionBD.Comentarios.Where(w => w.eventoId == listaEventos[Int32.Parse(evento) - 1].eventoId).Select(s => s).ToList();
            return resul;
            
        }

        public List<Comentario> getComentariosDeUsuario()
        {
           
                var listaUsuarios = conexionBD.Usuarios.OrderBy(o => o.usuarioId)
                                                       .ToList();
                var i = 1;

                foreach (Usuario us in listaUsuarios)
                {
                    Console.WriteLine(i + " -" + us.usuarioId);
                    i++;
                }

                Console.WriteLine("Elige usuario");
                string user = Console.ReadLine();

                //Consulta
                var resul = conexionBD.Comentarios.Where(w => w.usuarioId == listaUsuarios[Int32.Parse(user) - 1].usuarioId)
                                                  .Select(s =>s) 
                                                  .ToList();
                return resul;
            
            
        }

        //El tipo de dato IEnumerabe<dynamic> es porque devuelve una lista creada al vuelo
        public IEnumerable<dynamic> getNumComentariosPorCategoria()
        {
            
            var resul = conexionBD.Comentarios.GroupBy(g => g.categoriaId)
                                              .Select(s => new
                                                            {
                                                            categoria = s.Key,
                                                            cantidadComentarios = s.Count()
                                                            })          
                                              .ToList();
              
            return resul ;
            
        }

    }
}
