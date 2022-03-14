using MeteDatosEventos.Daos;
using MeteDatosEventos.Data;
using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.DaoImpl
{
    class CategoriaDaoImpl : CategoriaDao
    {

        private List<Categoria> categorias;
        ApiContext conexionBD;

        //Inyeccion de dependencia
        public CategoriaDaoImpl(ApiContext conexionBD)
        {
            this.conexionBD = conexionBD;
        }

        public Categoria getCategoria(string id)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> getCategorias()
        {

            categorias = conexionBD.Categorias.ToList();
            return categorias;
        }
    }
}
