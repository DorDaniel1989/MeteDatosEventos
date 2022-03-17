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
            int opcionUsuario = Int32.Parse(Console.ReadLine());
            Console.Beep(600, 90);


            Console.Clear();
            //MOSTRAMOS LAS CATEGORIAS POR PANTALLA
            Console.WriteAscii("CATEGORIAS", Color.LightGoldenrodYellow);
            var listaCategorias = conexionBD.Categorias.OrderBy(o => o.CategoriaId).ToList();
            var k = 1;

            foreach (Categoria cat in listaCategorias)
            {
                Console.WriteLine(k + " -" + cat.CategoriaId);
                k++;
            }

            Console.WriteLine("Elige categoria", Color.GreenYellow);
            int opcionCategoria = Int32.Parse(Console.ReadLine());
            Console.Beep(600, 90);
            Console.Clear();
            //MOSTRAMOS LOS EVENTOS FILTRADOS POR CATEGORIAS
            Console.WriteAscii("EVENTOS", Color.LightGoldenrodYellow);
              
            var listaEventos = conexionBD.Eventos.OrderBy(o => o.EventoId).Where(w=>w.CategoriaId==listaCategorias[opcionCategoria -1].CategoriaId).ToList();
            var x = 1;

            foreach (Evento ev in listaEventos)
            {
                Console.WriteLine(x + " -" + ev.EventoId);
                x++;
            }

            Console.WriteLine("Elige evento en el que comentar" , Color.GreenYellow);
            int opcionEvento = Int32.Parse(Console.ReadLine());
            Console.Beep(600, 90);
            Console.WriteLine("Introduce el comentario");
            string comentarioTxt = Console.ReadLine();
            Console.Beep(600, 90);
            Comentario comentario= new Comentario();
             
            comentario.UsuarioId = listaUsuarios[opcionUsuario - 1 ].usuarioId;
            comentario.EventoId = listaEventos[opcionEvento - 1 ].EventoId;
            comentario.ComentarioTxt = comentarioTxt;
            comentario.FechaComentario = "Hoy";
            comentario.CategoriaId = listaCategorias[opcionCategoria - 1].CategoriaId;

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
      
        public string getNumDeComentariosDeUnEvento()
        {

            var listaEventos = conexionBD.Eventos.OrderBy(o => o.EventoId).ToList();
            var i = 1;

            foreach (Evento eve in listaEventos)
            {
                Console.WriteLine(i + " -" + eve.EventoId);
                i++;
            }

            Console.WriteLine("Elige el evento");
            int opcion = Int32.Parse(Console.ReadLine());
            Console.Beep(600, 90);
            var resul = conexionBD.Comentarios.GroupBy(g => g.EventoId).Select(s => new
            {
                evento = s.Key,
                cantidad = s.Count().ToString()

            }).Where(w => w.evento == listaEventos[opcion -1].EventoId).ToList();

            //Parseamos a string la lista anonima que devuelve la consulta
            string resulPareseado="";
            try
            {
                resulPareseado= String.Format("   |{0,30}|{1,24}|", resul[0].evento, resul[0].cantidad) ;
            }
            catch(Exception e)
            {
                resulPareseado = "       SIN   COMENTARIOS   " ; 
            }

            return resulPareseado;
            


        }

        public string  getNumDeComentariosUsuario()
        {
            
                var listaUsuarios = conexionBD.Usuarios.OrderBy(o => o.usuarioId).ToList();
                string resulPareseado="";
                var i = 1;

                foreach (Usuario us in listaUsuarios)
                {
                    Console.WriteLine(i + " -" + us.usuarioId);
                    i++;
                }

                Console.WriteLine("Elige usuario");
                int opcion = Int32.Parse(Console.ReadLine());
                Console.Beep(600, 90);
              

                var resul = conexionBD.Comentarios.GroupBy(g => g.UsuarioId).Select(s => new
                    {
                        usuario = s.Key,
                        cantidad = s.Count().ToString()

                    }).Where(w => w.usuario == listaUsuarios[opcion - 1].usuarioId).ToList();

                //Parseamos a string la lista anonima que devuelve la consulta
                try
                {
                    resulPareseado = String.Format("   |{0,30}|{1,24}|", resul[0].usuario, resul[0].cantidad);
                }catch(Exception ex) {

                resulPareseado = "       SIN   COMENTARIOS   ";

                }

             

                return resulPareseado;
            


        }

        public List<Comentario> getComentarios()
        {
            comentarios = conexionBD.Comentarios.ToList();
            return comentarios;
        }

        public List<Comentario> getComentariosDeEvento()
        {
            var listaEventos = conexionBD.Eventos.OrderBy(o => o.EventoId).ToList();
            var i = 1;

            foreach (Evento eve in listaEventos)
            {
                Console.Write((i + " -" ) , Color.GreenYellow);
                Console.Write(eve.EventoId , Color.Orange);
                Console.WriteLine();
                i++;
            }

            Console.WriteLine("Elige un evento" , Color.GreenYellow);
            string evento = Console.ReadLine();
            Console.Beep(600, 90);

            //Console.WriteLine(Int32.Parse(evento));
            //Console.WriteLine(listaEventos[Int32.Parse(evento)-1].eventoId);

            var resul = conexionBD.Comentarios.Where(w => w.EventoId == listaEventos[Int32.Parse(evento) - 1].EventoId).Select(s => s).ToList();
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
                Console.Beep(600, 90);

                //Consulta
                var resul = conexionBD.Comentarios.Where(w => w.UsuarioId == listaUsuarios[Int32.Parse(user) - 1].usuarioId)
                                                      .Select(s =>s) 
                                                      .ToList();
                return resul;
            
            
        }

        public IEnumerable<dynamic> getNumComentariosPorCategoria()
        {
            
            var resul = conexionBD.Comentarios.GroupBy(g => g.CategoriaId)
                                              .Select(s => new
                                                            {
                                                            categoria = s.Key,
                                                            cantidadComentarios = s.Count()
                                                            }).OrderByDescending(o=>o.cantidadComentarios)          
                                              .ToList();
              
            return resul ;
            
        }

        public IEnumerable<dynamic> getNumDeComentariosUsuarioAgrupados()
        {
            var resul = conexionBD.Comentarios.GroupBy(g => g.UsuarioId)
                                             .Select(s => new
                                             {
                                                 usuario = s.Key,
                                                 cantidadComentarios = s.Count()
                                             }).OrderByDescending(o=>o.cantidadComentarios)
                                             .ToList();

            return resul;
        }

        public IEnumerable<dynamic> getNumDeComentariosEventosAgrupados()
        {
            var resul = conexionBD.Comentarios.GroupBy(g => g.EventoId)
                                               .Select(s => new
                                               {
                                                   evento = s.Key,
                                                   cantidadComentarios = s.Count()
                                               }).OrderByDescending(o=>o.cantidadComentarios)
                                               .ToList();

            return resul;
        }

        public void deleteComentario(string comentarioId)
        {
            throw new NotImplementedException();
        }

        public void updateComentario(string comentario)
        {
            throw new NotImplementedException();
        }
    }
}
