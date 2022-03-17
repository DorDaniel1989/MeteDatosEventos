using MeteDatosEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteDatosEventos.Daos
{
    interface CategoriaDao
    {
        Categoria getCategoria(string id);
        void saveCategoria(Categoria categoria);
        void deleteCategoria(string id);
        void updateCategoria(int id, Categoria categoria);
        List<Categoria> getCategorias();

    }
}
