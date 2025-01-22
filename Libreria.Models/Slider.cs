using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Models
{
    public class Slider
    {
        // Propiedades del modelo
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Nombre de Slider")]
        public string Nombre { get; set; }

        [Required]
        public bool Estado { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
    }
}
