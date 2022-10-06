using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pumbas.AccesoADatos;
using Pumbas.EntidadesDeNegocio;

namespace Pumbas.AccesoADatos
{
    public class CategoriaDAL
    {
        public static async Task<int> CrearAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCategoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var categoria = await bdContexto.Categoria.FirstOrDefaultAsync(s => s.Id == pCategoria.Id);
                categoria.IdProducto = pCategoria.IdProducto;
             
                categoria.Nombre = pCategoria.Nombre;
                categoria.Imagen = pCategoria.Imagen;
                bdContexto.Update(categoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var categoria = await bdContexto.Categoria.FirstOrDefaultAsync(s => s.Id == pCategoria.Id);

                bdContexto.Remove(categoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Categoria> ObtenerPorIdAsync(Categoria pCategoria)
        {
            var categoria = new Categoria();
            using (var bdContexto = new BDContexto())
            {
                categoria = await bdContexto.Categoria.FirstOrDefaultAsync(s => s.Id == pCategoria.Id);
            }
            return categoria;
        }
        public static async Task<List<Categoria>> ObtenerTodosAsync()
        {
            var categorias = new List<Categoria>();
            using (var bdContexto = new BDContexto())
            {
                categorias = await bdContexto.Categoria.ToListAsync();
            }
            return categorias;

        }
    internal static IQueryable<Categoria> QuerySelect(IQueryable<Categoria> pQuery, Categoria pCategoria)
        {
            if (pCategoria.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pCategoria.Id);
            if (pCategoria.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pCategoria.IdProducto);
       
            if (!String.IsNullOrWhiteSpace(pCategoria.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pCategoria.Nombre));

            if (!String.IsNullOrWhiteSpace(pCategoria.Imagen))
                pQuery = pQuery.Where(s => s.Imagen.Contains(pCategoria.Imagen));
            return pQuery;
            
        }
        public static async Task<List<Categoria>> BuscarAsync(Categoria pCategoria)
        {
            var categoria = new List<Categoria>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Categoria.AsQueryable();
                select = QuerySelect(select, pCategoria);
                categoria = await select.ToListAsync();
            }
            return categoria;
        }
        public static async Task<List<Categoria>> BuscarIncluirProductosAsync(Categoria pCategoria)
        {
            var Categoria = new List<Categoria>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Categoria.AsQueryable();

                select = QuerySelect(select, pCategoria).Include(s => s.Producto).AsQueryable();

                Categoria = await select.ToListAsync();
            }
            return Categoria;
        }
     
    }
}