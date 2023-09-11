using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLibros.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace CatalogoLibros.AccesoADatos 
{
    public class GeneroDAL
    {
        public static async Task<int> CrearAsync(Genero pGenero)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pGenero);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Genero pGenero)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var genero = await bdContexto.Genero.FirstOrDefaultAsync(c => c.Id == pGenero.Id);
                genero.Nombre = pGenero.Nombre;
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Genero pGenero)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var genero = await bdContexto.Genero.FirstOrDefaultAsync(c => c.Id == pGenero.Id);
                bdContexto.Genero.Remove(genero);
                result = await bdContexto.SaveChangesAsync();
                ;
            }
            return result;
        }
        public static async Task<Genero> ObtenerPorIdAsync(Genero pGenero)
        {
            var genero = new Genero();
            using (var bdContexto = new BDContexto())
            {
                genero = await bdContexto.Genero.FirstOrDefaultAsync(c => c.Id == pGenero.Id);
            }
            return genero;
        }
        public static async Task<List<Genero>> ObtenerTodosAsync()
        {
            var genero = new List<Genero>();
            using (var bdContexto = new BDContexto())
            {
                genero = await bdContexto.Genero.ToListAsync();
            }
            return genero;
        }
        internal static IQueryable<Genero> QuerySelect(IQueryable<Genero> pQuery,
                                   Genero pGenero)
        {
            if (pGenero.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pGenero.Id);

            if (!string.IsNullOrEmpty(pGenero.Nombre))
                pQuery = pQuery.Where(c => c.Nombre.Contains(pGenero.Nombre));
            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pGenero.top_aux > 0)
                pQuery = pQuery.Take(pGenero.top_aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Genero>> BuscarAsync(Genero pGenero)
        {
            var genero = new List<Genero>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Genero.AsQueryable();
                select = QuerySelect(select, pGenero);
                genero = await select.ToListAsync();
            }
            return genero;
        }
    }

}

