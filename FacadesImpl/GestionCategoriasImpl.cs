using MeteDatosEventos.DaoImpl;
using MeteDatosEventos.Daos;
using MeteDatosEventos.Data;
using MeteDatosEventos.Facades;
using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.FacadesImpl
{
    class GestionCategoriasImpl : GestionCategorias
    {
        //Instanciamos el objeto que se conectara a la base de datos y del que nos valdremos y su dependencia
        CategoriaDao categoriaDao;
       
        //Inyeccion de dependencias
        public GestionCategoriasImpl(ApiContext conexionBD)
        {
            categoriaDao = new CategoriaDaoImpl(conexionBD);
            
        }

        public List<Categoria> getCategorias()
        {
            return categoriaDao.getCategorias();
        }
    }
}
