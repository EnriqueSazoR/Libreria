using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Models
{
    public class SobreNosotro
    {
        // Propiedades
        [Key]
        public int ID { get; set; } // este ID siempre será uno, ya que solo habrá una visión, misión e información general pero serán editables

      
        public DateTime FechaActualizacion { get; set; } // este campo se actualizará automaticamente cada que se haga una edición de los datos

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Misión")]
        public string Mision { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Visión")]
        public string Vision { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Información General")]
        public string Informacion { get; set; }

    }
}
