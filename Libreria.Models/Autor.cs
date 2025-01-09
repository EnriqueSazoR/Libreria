using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Models
{
    public class Autor
    {
        // Propiedades del modelo
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Autor")]
        public string NombreAutor { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Biografía del autor")]
        public string Biografia { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
    }
}
