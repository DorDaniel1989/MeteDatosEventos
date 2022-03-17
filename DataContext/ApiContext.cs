using MeteDatosEventos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeteDatosEventos.Data
{

    public class ApiContext : DbContext
    {
        public string connString;
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
        public ApiContext()
        {
            //connString = "Server=185.60.40.210\\SQLEXPRESS,58015;Database=ProyectoEventos;User Id=sa;Password=Pa88word";
             connString= "server=localhost;database=eventos; Uid=root";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(connString, new MySqlServerVersion(new Version()));

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Localizacion> Localizaciones { get; set; }


    }
}