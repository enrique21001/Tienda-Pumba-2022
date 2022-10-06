using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pumbas.AccesoADatos;
using Pumbas.EntidadesDeNegocio;

namespace Pumbas.LogicaDeNegocio
{
    public class CategoriaBl
    {
        public async Task<int> CrearAsync(Categoria pUsuario)
        {
            return await CategoriaDAL.CrearAsync(pUsuario);
        }

        public async Task<int> ModificarAsync(Categoria pUsuario)
        {
            return await CategoriaDAL.ModificarAsync(pUsuario);
        }

        public async Task<int> EliminarAsync(Categoria pUsuario)
        {
            return await CategoriaDAL.EliminarAsync(pUsuario);
        }

        public async Task<Categoria> ObtenerPorIdAsync(Categoria pUsuario)
        {
            return await CategoriaDAL.ObtenerPorIdAsync(pUsuario);
        }

        public async Task<List<Categoria>> ObtenerTodosAsync()
        {
            return await CategoriaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Categoria>> BuscarAsync(Categoria pUsuario)
        {
            return await CategoriaDAL.BuscarAsync(pUsuario);
        }
        public static async Task<List<Categoria>> BuscarIncluirProductosAsync(Categoria pCategoria) 
        { return await CategoriaDAL.BuscarIncluirProductosAsync(pCategoria); }
    }

    
    }
