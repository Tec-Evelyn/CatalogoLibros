using CatalogoLibros.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoLibros.AccesoADatos
{
    public class AutorDAL
    {
        public static async Task<int> CrearAsync(Autor pAutor)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pAutor);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Autor pAutor)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var autor = await bdContexto.Autor.FirstOrDefaultAsync(a => a.Id == pAutor.Id);
                autor.Nombre = pAutor.Nombre;
                bdContexto.Update(autor);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Autor pAutor)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var autor = await bdContexto.Autor.FirstOrDefaultAsync(a => a.Id == pAutor.Id);
                bdContexto.Autor.Remove(autor);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Autor> ObtenerPorIdAsync(Autor pAutor)
        {
            var autor = new Autor();
            using (var bdContexto = new BDContexto())
            {
                autor = await bdContexto.Autor.FirstOrDefaultAsync(a => a.Id == pAutor.Id);
            }
            return autor;
        }
        public static async Task<List<Autor>> ObtenerTodosAsync()
        {
            var autores = new List<Autor>();
            using (var bdContexto = new BDContexto())
            {
                autores = await bdContexto.Autor.ToListAsync();
            }
            return autores;
        }
        internal static IQueryable<Autor> QuerySelect(IQueryable<Autor> pQuery, Autor pAutor)
        {
            if (pAutor.Id > 0)
                pQuery = pQuery.Where(a => a.Id == pAutor.Id);

            if (!string.IsNullOrWhiteSpace(pAutor.Nombre))
                pQuery = pQuery.Where(a => a.Nombre.Contains(pAutor.Nombre));

            pQuery = pQuery.OrderByDescending(a => a.Id).AsQueryable();

            if (pAutor.Top_Aux > 0)
                pQuery = pQuery.Take(pAutor.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Autor>> BuscarAsync(Autor pAutor)
        {
            var autores = new List<Autor>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Autor.AsQueryable();
                select = QuerySelect(select, pAutor);
                autores = await select.ToListAsync();
            }
            return autores;
        }

    }
}
