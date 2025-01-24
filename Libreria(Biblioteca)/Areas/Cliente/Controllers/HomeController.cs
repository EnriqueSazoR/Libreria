using System.Diagnostics;
using Libreria.AccesoDatos.Data.Repository.IRepository;
using Libreria.Models.ViewModels;
using Libreria_Biblioteca_.Areas.Admin.Controllers;
using Libreria_Biblioteca_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Libreria_Biblioteca_.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 4)
        {
            var libros = _contenedorTrabajo.Libro.AsQuerable().Include(m => m.Autor);

            // paginar libros
            var paginatedEntries = libros.Skip((page - 1) * pageSize).Take(pageSize);

            HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.Slider.GetAll(),
                ListaLibros = paginatedEntries.ToList(),
                PageIndex = page,
                TotalPage = (int)Math.Ceiling(libros.Count() / (double)pageSize)
            };

            ViewBag.IsHome = true;

            return View(homeVM);
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var libroDesdeBd = _contenedorTrabajo.Libro.Get(id);
            return View(libroDesdeBd);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
