﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Libro> ListaLibros { get; set; }

        // Paginación
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
    }
}
