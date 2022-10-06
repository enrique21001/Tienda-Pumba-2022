using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pumbas.EntidadesDeNegocio
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Producto")]
        [Required(ErrorMessage = "Producto es obligatorio")]
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 40 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Imagen es obligatorio")]
        [StringLength(200, ErrorMessage = "Maximo 2000 caracteres")]
        public string Imagen { get; set; }

        public Producto Producto { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

       
    }
}
