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
    public interface ICategoriaService
    {
       
            Task<IEnumerable<Categoria>> GetAll();
            Task<IEnumerable<Categoria>> GetByProsucto(int idProducto);
            Task<Categoria> GetById(int id);
        }
    }

