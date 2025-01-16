using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Models.ViewModels
{
    public class LibroVM
    {
        public Libro Libro { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
        public IEnumerable<SelectListItem> ListaAutores { get; set; }
    }
}
