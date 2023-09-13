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
    public class GeneroDALTests
    {
        private static Genero generoInicial = new Genero { Id = 1};


        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var genero = new Genero();
            genero.Nombre = "Crecimiento personal";
            int result = await GeneroDAL.CrearAsync(genero);
            Assert.AreNotEqual(0, result);
            generoInicial.Id = genero.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var genero = new Genero();
            genero.Id = generoInicial.Id;
            genero.Nombre = "Ciencia ficcion";
            int result = await GeneroDAL.ModificarAsync(genero);
            Assert.AreNotEqual(0, result);
        }
        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var genero = new Genero();
            genero.Id = generoInicial.Id;

            var resultGenero = await GeneroDAL.ObtenerPorIdAsync(genero);
            Assert.AreEqual(genero.Id, resultGenero.Id);
           
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
          var resultGenero = await GeneroDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultGenero.Count);

        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var genero = new Genero();
            genero.Nombre = "C";
            genero.top_aux = 10;
            var resultGenero = await GeneroDAL.BuscarAsync(genero);
            Assert.AreNotEqual(0, resultGenero.Count);
        }
        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var genero = new Genero();
            genero.Id = generoInicial.Id;
            int result = await GeneroDAL.EliminarAsync(genero);
            Assert.AreNotEqual(0, result);

        }


    }
}