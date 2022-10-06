using Pumbas.ClienteBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pumbas.ClienteBlazor.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;
        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            string resp = await _httpClient.GetStringAsync($"Categoria");
            return JsonSerializer.Deserialize<IEnumerable<Categoria>>(resp, options);
        }
        public async Task<IEnumerable<Categoria>> GetByProsucto(int idProducto)
        {
            var resp = await _httpClient.PostAsJsonAsync($"Categoria/Buscar", new { idProducto = idProducto });
            string respString = await resp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Categoria>>(respString, options);
        }
        public async Task<Categoria> GetById(int id)
        {
            string resp = await _httpClient.GetStringAsync($"Categoria/{id}");
            return JsonSerializer.Deserialize<Categoria>(resp, options);

        }
        
    
    }
}
