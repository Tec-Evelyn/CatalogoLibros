using System;
using System.Collections.Generic;
//using System.Diagnostics.Contracts;
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
                bdContexto.Update(genero);
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
        internal static IQueryable<Genero> QuerySelect(IQueryable<Genero> pQuery, Genero pGenero)
        {
            if (pGenero.Id > 0)
                pQuery = pQuery.Where(g => g.Id == pGenero.Id);

            if (!string.IsNullOrWhiteSpace(pGenero.Nombre))
                pQuery = pQuery.Where(g => g.Nombre.Contains(pGenero.Nombre));

            pQuery = pQuery.OrderByDescending(g => g.Id).AsQueryable();

            if (pGenero.Top_Aux > 0)
                pQuery = pQuery.Take(pGenero.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Genero>> BuscarAsync(Genero pGenero)
        {
            var generos = new List<Genero>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Genero.AsQueryable();
                select = QuerySelect(select, pGenero);
                generos = await select.ToListAsync();
            }
            return generos;
        }
    }
}

