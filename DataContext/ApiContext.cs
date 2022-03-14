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
            connString = "Server=185.60.40.210\\SQLEXPRESS,58015;Database=ProyectoEventos;User Id=sa;Password=Pa88word";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connString);

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }


    }
}