using CatalogoLibros.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoLibros.AccesoADatos
{
    public class LibroDAL
    {
        public static async Task<int> CrearAsync(Libro pLibro)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pLibro);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Libro pLibro)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var libro = await bdContexto.Libro.FirstOrDefaultAsync(b => b.Id == pLibro.Id);
                libro.IdAutor = pLibro.IdAutor;
                libro.IdCategoria = pLibro.IdCategoria;
                libro.IdGenero = pLibro.IdGenero;
                libro.Nombre = pLibro.Nombre;
                libro.Imagen = pLibro.Imagen;
                libro.NumPaginas = pLibro.NumPaginas;
                libro.FechaPublicacion = pLibro.FechaPublicacion;
                bdContexto.Update(libro);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Libro pLibro)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var libro = await bdContexto.Libro.FirstOrDefaultAsync(b => b.Id == pLibro.Id);
                bdContexto.Libro.Remove(libro);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Libro> ObtenerPorIdAsync(Libro pLibro)
        {
            var libro = new Libro();
            using (var bdContexto = new BDContexto())
            {
                libro = await bdContexto.Libro.FirstOrDefaultAsync(b => b.Id == pLibro.Id);
            }
            return libro;
        }

        public static async Task<List<Libro>> ObtenerTodosAsync()
        {
            var libros = new List<Libro>();
            using (var bdContexto = new BDContexto())
            {
                libros = await bdContexto.Libro.ToListAsync();
            }
            return libros;
        }

        internal static IQueryable<Libro> QuerySelect(IQueryable<Libro> pQuery, Libro pLibro)
        {
            if (pLibro.Id > 0)
                pQuery = pQuery.Where(b => b.Id == pLibro.Id);
            if (pLibro.IdAutor > 0)
                pQuery.Where(b => b.IdAutor == pLibro.IdAutor);
            if (pLibro.IdCategoria > 0)
                pQuery.Where(b => b.IdCategoria == pLibro.IdCategoria);
            if (pLibro.IdGenero > 0)
                pQuery.Where(b => b.IdGenero == pLibro.IdGenero);
            if (!string.IsNullOrWhiteSpace(pLibro.Nombre))
                pQuery = pQuery.Where(b => b.Nombre.Contains(pLibro.Nombre));
            pQuery = pQuery.OrderByDescending(b => b.Id).AsQueryable();
            if (pLibro.Top_Aux > 0)
                pQuery = pQuery.Take(pLibro.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Libro>> BuscarAsync(Libro pLibro)
        {
            var libros = new List<Libro>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Libro.AsQueryable();
                select = QuerySelect(select, pLibro);
                libros = await select.ToListAsync();
            }
            return libros;
        }

        public static async Task<List<Libro>> BuscarIncluirRelacionesAsync(Libro pLibro)
        {
            var libros = new List<Libro>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Libro.AsQueryable();
                select = QuerySelect(select, pLibro).Include(b => b.Autor).Include(b => b.Categoria).Include(b => b.Genero).AsQueryable();
                libros = await select.ToListAsync();

            }
            return libros;
        }
    }
}
