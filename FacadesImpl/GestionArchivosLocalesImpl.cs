using MeteDatosEventos.Data;
using MeteDatosEventos.Facades;
using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.FacadesImpl
{
    class GestionArchivosLocalesImpl : GestionArchivosLocales
    {
        string url = "C:\\Users\\danie\\OneDrive\\Escritorio\\ProyectoFinal\\MeteDatosEventos\\DataContext\\";
        string fileNameUser = "usuario.json";
        string fileNameIns = "inscripcion.json";
        string fileNameEven = "eventos.json";
        string fileNameComen = "comentario.json";
        string fileNameCat = "categoria.json";

       
        //Metodos que extraen la información de los archivos json
        List<Usuario> getUsuariosJson()
        {
            var jsonString = File.ReadAllText(url + fileNameUser);
            var listaUsuarios = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(jsonString);
            return listaUsuarios;
        }

        List<Inscripcion> getInscripcionesJson()
        {
            var jsonString = File.ReadAllText(url + fileNameIns);
            var listaUsuarios = System.Text.Json.JsonSerializer.Deserialize<List<Inscripcion>>(jsonString);
            return listaUsuarios;
        }

        List<Evento> getEventosJson()
        {
            var jsonString = File.ReadAllText(url + fileNameEven);
            var listaUsuarios = System.Text.Json.JsonSerializer.Deserialize<List<Evento>>(jsonString);
            return listaUsuarios;
        }

        List<Comentario> getComentariosJson()
        {
            var jsonString = File.ReadAllText(url + fileNameComen);
            var listaUsuarios = System.Text.Json.JsonSerializer.Deserialize<List<Comentario>>(jsonString);
            return listaUsuarios;
        }

        List<Categoria> getCategoriasJson()
        {
            var jsonString = File.ReadAllText(url + fileNameCat);
            var listaUsuarios = System.Text.Json.JsonSerializer.Deserialize<List<Categoria>>(jsonString);
            return listaUsuarios;
        }



        public void insertarDatos()
        {
          
                List<Categoria> listaCategorias = getCategoriasJson();
                List<Evento> listaEventos = getEventosJson();
                List<Usuario> listaUsuarios = getUsuariosJson();
                List<Inscripcion> listaInscripciones = getInscripcionesJson();
                List<Comentario> listaComentarios = getComentariosJson();


                using (var db = new ApiContext())
                {

                //Metodo para vaciar todas las tablas

                //  (Por implementar)

                //Insertando datos.....
                //Añadiendo de categorias
                if (!db.Categorias.Any())
                    {
                        foreach (Categoria cat in listaCategorias)
                        {
                            Console.WriteLine(cat);
                            db.Categorias.Add(cat);

                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Las categorias ya han sido introducidos");
                    }

                //Añadiendo de Eventos

                if (!db.Eventos.Any())
                    {
                        foreach (Evento eve in listaEventos)
                        {
                            Console.WriteLine(eve);
                            db.Eventos.Add(eve);

                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Los eventos ya han sido introducidos");
                    }

                //Añadiendo de Usuarios

                if (!db.Usuarios.Any())
                    {
                        foreach (Usuario user in listaUsuarios)
                        {
                            Console.WriteLine(user);
                            db.Usuarios.Add(user);

                        }
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Los usuarios ya han sido introducidos");
                    }

                //Añadiendo de Comentarios

                if (!db.Comentarios.Any())
                    {
                        foreach (Comentario com in listaComentarios)
                        {
                            Console.WriteLine(com);
                            db.Comentarios.Add(com);

                        }
                        db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Los comentarios ya han sido introducidos");
                }

                //Añadiendo Inscripciones

                if (!db.Inscripciones.Any())
                {
                    foreach (Inscripcion ins in listaInscripciones)
                    {
                        Console.WriteLine(ins);
                        db.Inscripciones.Add(ins);

                    }
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Las inscripciones ya han sido introducidos");
                }
            }
        }
    }
}