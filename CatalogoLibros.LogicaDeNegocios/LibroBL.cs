using CatalogoLibros.AccesoADatos;
using CatalogoLibros.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoLibros.LogicaDeNegocios
{
    public class LibroBL
    {
        public async Task<int> CrearAsync(Libro pLibro)
        {
            return await LibroDAL.CrearAsync(pLibro);
        }

        public async Task<int> ModificarAsync(Libro pLibro)
        {
            return await LibroDAL.ModificarAsync(pLibro);
        }

        public async Task<int> EliminarAsync(Libro pLibro)
        {
            return await LibroDAL.EliminarAsync(pLibro);
        }

        public async Task<Libro> ObtenerPorIdAsync(Libro pLibro)
        {
            return await LibroDAL.ObtenerPorIdAsync(pLibro);
        }

        public async Task<List<Libro>> ObtenerTodosAsync()
        {
            return await LibroDAL.ObtenerTodosAsync();
        }

        public async Task<List<Libro>> BuscarAsync(Libro pLibro)
        {
            return await LibroDAL.BuscarAsync(pLibro);
        }

        public async Task<List<Libro>> BuscarIncluirRelacionesAsync(Libro pLibro)
        {
            return await LibroDAL.BuscarIncluirRelacionesAsync(pLibro);
        }
    }
}
