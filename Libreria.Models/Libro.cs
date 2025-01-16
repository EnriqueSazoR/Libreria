using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Models
{
    public class Libro
    {
        // Propiedades
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Libro")]
        public string NombreLibro { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(200, ErrorMessage = "La sinopsis no pude exceder los 200 caracteres")]
        public string Sinopsis { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de páginas debe ser mayor a 0")]
        [Display(Name = "Número de páginas")]
        public int NumeroPaginas { get; set; }

        // Relación entre categoría y libro
        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        // Relación entre autor y libro
        [Required(ErrorMessage = "El autor es obligatorio")]
        public int IdAutor { get; set; }
        [ForeignKey("IdAutor")]
        public Autor Autor { get; set; }


    }
}
