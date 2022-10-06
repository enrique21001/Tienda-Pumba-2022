using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumbas.ClienteBlazor.Models
{
    public class Categoria
    {

        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string Nombre { get; set; }

        public string Imagen { get; set; }
    }
}
