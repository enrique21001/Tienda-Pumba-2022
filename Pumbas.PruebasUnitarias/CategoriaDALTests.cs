using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pumbas.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pumbas.EntidadesDeNegocio;

namespace Pumbas.AccesoADatos.Tests
{
    [TestClass()]
    public class CategoriaDALTests
    {
        private static Categoria categoriaInicial = new Categoria
        {
            Id = 1,
            IdProducto = 3,
          
        };
        [TestMethod()]
    public async Task T1CrearAsyncTest()
        {
            var categoria = new Categoria();
            categoria.IdProducto = categoriaInicial.IdProducto;
            categoria.Nombre = "Zapatos";
            categoria.Imagen = "CAMISAS";
            int result = await CategoriaDAL.CrearAsync(categoria);
            Assert.AreNotEqual(0, result);
            categoriaInicial.Id = categoria.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            categoria.IdProducto = categoriaInicial.IdProducto;
            categoria.Nombre = "Zapatillas";
            categoria.Imagen = "Camisas de equipos de la LFP";
        
            int result = await CategoriaDAL.ModificarAsync(categoria);
            Assert.AreNotEqual(0, result);

        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            var resultCategoria = await CategoriaDAL.ObtenerPorIdAsync(categoria);
            Assert.AreEqual(categoria.Id, resultCategoria.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultCategoria = await CategoriaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultCategoria.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.IdProducto = categoriaInicial.IdProducto; 
            categoria.Nombre = "l";
            categoria.Imagen = "s";  
          
            var resultCategoria = await CategoriaDAL.BuscarAsync(categoria);
            Assert.AreNotEqual(0, resultCategoria.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirProductosAsyncTest()
        {
            var categoria = new Categoria();
            categoria.IdProducto = categoriaInicial.IdProducto;
            categoria.Nombre = "z";
            categoria.Imagen = "c";
         
            var resultCategoria = await CategoriaDAL.BuscarIncluirProductosAsync(categoria);
            Assert.AreNotEqual(0, resultCategoria.Count);
            var ultimoProducto = resultCategoria.FirstOrDefault();
            Assert.IsTrue(ultimoProducto.Producto != null && categoria.IdProducto == ultimoProducto.Producto.Id);
        }

    

        [TestMethod()]
        public async Task T8EliminarAsyncTest()
        {
            var categoria = new Categoria();
            categoria.Id = categoriaInicial.Id;
            int result = await CategoriaDAL.EliminarAsync(categoria);
            Assert.AreNotEqual(0, result);
        }
    }
}