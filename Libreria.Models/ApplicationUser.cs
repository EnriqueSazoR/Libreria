﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Propiedades adicionales
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Ciudad { get; set; }
    }
}
