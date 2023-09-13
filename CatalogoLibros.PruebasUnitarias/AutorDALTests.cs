using Microsoft.VisualStudio.TestTools.UnitTesting;
using CatalogoLibros.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoLibros.EntidadesDeNegocio;

namespace CatalogoLibros.AccesoADatos.Tests
{
    [TestClass()]
    public class AutorDALTests
    {
        private static Autor autorInicial = new Autor { Id = 2 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var autor = new Autor();
            autor.Nombre = "James Clear";
            int result = await AutorDAL.CrearAsync(autor);
            Assert.AreNotEqual(0, result);
            autorInicial.Id = autor.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var autor = new Autor();
            autor.Id = autorInicial.Id;
            autor.Nombre = "James";
            int result = await AutorDAL.ModificarAsync(autor);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var autor = new Autor();
            autor.Id = autorInicial.Id;
            var resultAutor = await AutorDAL.ObtenerPorIdAsync(autor);
            Assert.AreEqual(autor.Id, resultAutor.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultAutores = await AutorDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultAutores.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var autor = new Autor();
            autor.Nombre = "j";
            autor.Top_Aux = 10;
            var resultAutores = await AutorDAL.BuscarAsync(autor);
            Assert.AreNotEqual(0, resultAutores.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest() 
        {
            var autor = new Autor();
            autor.Id = autorInicial.Id;
            int result = await AutorDAL.EliminarAsync(autor);
            Assert.AreNotEqual(0, result);
        }
    }
}