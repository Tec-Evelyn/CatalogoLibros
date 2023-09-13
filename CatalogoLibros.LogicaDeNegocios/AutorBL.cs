using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLibros.AccesoADatos;
using CatalogoLibros.EntidadesDeNegocio;

namespace CatalogoLibros.LogicaDeNegocios
{
    public class AutorBL
    {
        public async Task<int> CrearAsync(Autor pAutor)
        {
            return await AutorDAL.CrearAsync(pAutor);
        }

        public async Task<int> ModificarAsync(Autor pAutor)
        {
            return await AutorDAL.ModificarAsync(pAutor);
        }

        public async Task<int> EliminarAsync(Autor pAutor)
        {
            return await AutorDAL.EliminarAsync(pAutor);
        }

        public async Task<Autor> ObtenerPorIdAsync(Autor pAutor)
        {
            return await AutorDAL.ObtenerPorIdAsync(pAutor);
        }

        public async Task<List<Autor>> ObtenerTodosAsync()
        {
            return await AutorDAL.ObtenerTodosAsync();
        }

        public async Task<List<Autor>> BuscarAsync(Autor pAutor)
        {
            return await AutorDAL.BuscarAsync(pAutor);
        }
    }
}
