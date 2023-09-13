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
    public class CategoriaDALTests
    {
        private static Categoria categoriaInicial = new Categoria { Id = 2 };
        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Nombre = "Autoayuda";
            int result = await CategoriaDAL.CrearAsync(categoria);
            Assert.AreNotEqual(0, result);
            categoriaInicial.Id = categoria.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            categoria.Nombre = "AutoAyudas";
            int result = await CategoriaDAL.ModificarAsync(categoria);
            Assert.AreNotEqual(0, result);
           
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            var resultcategoria = await CategoriaDAL.ObtenerPorIdAsync(categoria);
            Assert.AreEqual(categoria.Id, resultcategoria.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultcategorias = await CategoriaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultcategorias.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Nombre = "a";
            categoria.Top_aux = 10;
            var resultcategorias = await CategoriaDAL.BuscarAsync(categoria);
            Assert.AreNotEqual(0, resultcategorias.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            int result = await CategoriaDAL.EliminarAsync(categoria);
            Assert.AreNotEqual(0, result);
        }
    }
}