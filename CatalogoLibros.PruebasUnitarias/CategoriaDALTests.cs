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
            //crear instancia del modelo Categoria
            var categoria = new Categoria();
            //Llenar propiedades del objeto
            categoria.Nombre = "Autoayuda";
            int result = await CategoriaDAL.CrearAsync(categoria);
            //Definir los asserts para la prueba
            Assert.AreNotEqual(0, result);
            categoriaInicial.Id = categoria.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            //crear instancia del modelo Categoria
            var categoria = new Categoria();
            //Llenar propiedades del objeto incluyendo el id
            categoria.Id = categoriaInicial.Id;
            categoria.Nombre = "AutoAyudas";
            int result = await CategoriaDAL.ModificarAsync(categoria);
            //Definir los asserts para la prueba
            Assert.AreNotEqual(0, result);
           
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            //crear instancia del modelo Categoria
            var categoria = new Categoria();
            //obtener el id de la propiedad creada
            categoria.Id = categoriaInicial.Id;
            var resultcategoria = await CategoriaDAL.ObtenerPorIdAsync(categoria);
            //Definir los asserts para la prueba
            Assert.AreEqual(categoria.Id, resultcategoria.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            //Llamar metodo creado ObtenerTodosAsync 
            var resultcategorias = await CategoriaDAL.ObtenerTodosAsync();
            //Definir los asserts para la prueba
            Assert.AreNotEqual(0, resultcategorias.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            //crear instancia del modelo Departamento
            var categoria = new Categoria();
            //llenar propiedad del objeto
            categoria.Nombre = "a";
            categoria.Top_aux = 10;
            var resultcategorias = await CategoriaDAL.BuscarAsync(categoria);
            //Definir los asserts para la prueba
            Assert.AreNotEqual(0, resultcategorias.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            //crear instancia del modelo Departamento
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            int result = await CategoriaDAL.EliminarAsync(categoria);
            //Definir los asserts para la prueba
            Assert.AreNotEqual(0, result);
        }
    }
}