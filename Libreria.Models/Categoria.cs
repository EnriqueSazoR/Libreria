using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Models
{
    public class Categoria
    {
        // Definir propiedades
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Categoría")]
        public string? NombreCategoria { get; set; }

        [Display(Name = "Orden de visualización")]
        public int Orden { get; set; }
    }
}
