using Pumbas.EntidadesDeNegocio;
using Pumbas.LogicaDeNegocio;
using Pumbas.WebAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Pumbas.AccesoADatos;

namespace Pumbas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoriaController : ControllerBase
    {
        private CategoriaBl categoriaBL = new CategoriaBl();

        // Codigo para agregar la seguridad JWT
        private readonly IJwtAuthenticationService authService;
        public CategoriaController(IJwtAuthenticationService pAuthService)
        {
            authService = pAuthService;
        }
        //************************************************

        [HttpGet]
        public async Task<IEnumerable<Categoria>> Get()
        {
            return await categoriaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Categoria> Get(int id)
        {
            Categoria categoria = new Categoria();
            categoria.Id = id;
            return await categoriaBL.ObtenerPorIdAsync(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                await categoriaBL.CrearAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pcategoria)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCategoria = JsonSerializer.Serialize(pcategoria);
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(strCategoria, option);
            if (categoria.Id == id)
            {
                await categoriaBL.ModificarAsync(categoria);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Categoria categoria = new Categoria();
                categoria.Id = id;
                await categoriaBL.EliminarAsync(categoria);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /* [HttpPost("Buscar")]
         public async Task<List<Categoria>> Buscar([FromBody] object pcategoria)
         {

             var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
             string strCategoria = JsonSerializer.Serialize(pcategoria);
             Categoria categoria = JsonSerializer.Deserialize<Categoria>(strCategoria, option);
             var categorias = await categoriaBL.BuscarIncluirProductosAsync(categoria);
             categorias.ForEach(s => s.Producto.Categoria = null); // Evitar la redundacia de datos
             return categorias*/

        [HttpPost("Buscar")]
        public async Task<List<Categoria>> Buscar([FromBody] object pCategoria)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCategoria = JsonSerializer.Serialize(pCategoria);
            Categoria categoria = JsonSerializer.Deserialize<Categoria>(strCategoria, option);
            var categorias = await CategoriaBl.BuscarIncluirProductosAsync(categoria);
            categorias.ForEach(s => s.Producto.Categoria = null); // Evitar la redundacia de datos
            return categorias;
        }
    }

        

       
        }
    
