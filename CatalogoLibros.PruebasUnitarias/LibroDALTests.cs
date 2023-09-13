using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogoLibros.AccesoADatos;
using CatalogoLibros.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoLibros.AccesoADatos.Tests
{
    [TestClass()]
    public class LibroDALTests
    {
        private static Libro libroInicial = new Libro { Id = 3, IdAutor = 1, IdCategoria = 1, IdGenero = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var libro = new Libro();
            libro.IdAutor = libroInicial.IdAutor;
            libro.IdCategoria = libroInicial.IdCategoria;
            libro.IdGenero = libroInicial.IdGenero;
            libro.Nombre = "El Principito";
            libro.Imagen = "https://www.laesferaazul.com/wp-content/uploads/2022/09/Descubrir-el-principito-catalan-832x1024.jpg";
            libro.NumPaginas = 120;
            libro.FechaPublicacion = "06/04/1943";

            int result = await LibroDAL.CrearAsync(libro);
            Assert.AreNotEqual(0, result);
            libroInicial.Id = libro.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var libro = new Libro();
            libro.Id = libroInicial.Id;
            libro.IdAutor = libroInicial.IdAutor;
            libro.IdCategoria = libroInicial.IdCategoria;
            libro.IdGenero = libroInicial.IdGenero;
            libro.Nombre = " La obra del Principito";
            libro.Imagen = "https://www.laesferaazul.com/wp-content/uploads/2022/09/Descubrir-el-principito-catalan-832x1024.jpg";
            libro.NumPaginas = 130;
            libro.FechaPublicacion = "06/04/1943";

            int result = await LibroDAL.ModificarAsync(libro);
            Assert.AreNotEqual(0, result);
        }
 
        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var libro = new Libro();
            libro.Id = libroInicial.Id;
            var resultLibro = await LibroDAL.ObtenerPorIdAsync(libro);
            Assert.AreEqual(libro.Id, resultLibro.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultLibros = await LibroDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultLibros.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var libro = new Libro();
            libro.IdAutor = libroInicial.IdAutor;
            libro.IdCategoria = libroInicial.IdCategoria;
            libro.IdGenero = libroInicial.IdGenero;
            libro.Nombre = "A";
            libro.Top_Aux = 10;
            var resultLibros = await LibroDAL.BuscarAsync(libro);
            Assert.AreNotEqual(0, resultLibros.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirRelacionesAsyncTest()
        {
            var libro = new Libro();
            libro.IdAutor = libroInicial.IdAutor;
            libro.IdCategoria = libroInicial.IdCategoria;
            libro.IdGenero = libroInicial.IdGenero;
            libro.Nombre = "A";
            libro.Top_Aux = 10;
            var resultLibros = await LibroDAL.BuscarIncluirRelacionesAsync(libro);
            Assert.AreNotEqual(0, resultLibros.Count);
            var ultimoLibro = resultLibros.FirstOrDefault();
            Assert.IsTrue(ultimoLibro.Autor != null && libro.IdAutor == ultimoLibro.Autor.Id && ultimoLibro.Categoria != null && libro.IdCategoria == ultimoLibro.Categoria.Id && ultimoLibro.Genero != null && libro.IdGenero == ultimoLibro.Genero.Id);
          
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var libro = new Libro();
            libro.Id = libroInicial.Id;
            int result = await LibroDAL.EliminarAsync(libro);
            Assert.AreNotEqual(0, result);
        }

    }
}