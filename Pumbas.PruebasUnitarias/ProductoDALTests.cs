using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pumbas.AccesoADatos;
using Pumbas.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pumbas.AccesoADatos.Tests
{
    [TestClass()]

    public class ProductoDALTests
    {
        private static Producto productoInicial = new Producto { Id = 9 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var producto = new Producto();
            producto.Nombre = "Administrador";
            int result = await ProductoDAL.CrearAsync(producto);
            Assert.AreNotEqual(0, result);
            productoInicial.Id = producto.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
                producto.Nombre = "sos";
  
            int result = await ProductoDAL.ModificarAsync(producto);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            var resultProducto = await ProductoDAL.ObtenerPorIdAsync(producto);
            Assert.AreEqual(producto.Id, resultProducto.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultProductos = await ProductoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProductos.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var producto = new Producto();
            producto.Nombre = "o";
    

            producto.Top_Aux = 10;
            var resultProductos = await ProductoDAL.BuscarAsync(producto);
            Assert.AreNotEqual(0, resultProductos.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var producto = new Producto();
            producto.Id = productoInicial.Id;
            int result = await ProductoDAL.EliminarAsync(producto);
            Assert.AreNotEqual(0, result);
        }
    }
}