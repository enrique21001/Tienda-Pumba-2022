using Pumbas.ClienteBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumbas.ClienteBlazor.Services
{
   public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAll();
    }
}
