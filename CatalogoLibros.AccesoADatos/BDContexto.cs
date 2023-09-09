using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using CatalogoLibros.EntidadesDeNegocio;

namespace CatalogoLibros.AccesoADatos
{
    public class BDContexto : DbContext
    {
        //public DbSet<Rol> Rol { get; set; }
        //public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        //public DbSet<Genero> Genero{ get; set; }
        //public DbSet<Autor> Autor { get; set; }
        //public  DbSet<Libro> Libro { get; set; }

        protected override void onConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Josue-Perez;
                                               Initial Catalog=CatalogoLibros;
                                               Integrated  Security=True");
        }
    }
}
