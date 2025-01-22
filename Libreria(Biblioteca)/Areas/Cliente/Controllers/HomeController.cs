using System.Diagnostics;
using Libreria.AccesoDatos.Data.Repository.IRepository;
using Libreria.Models.ViewModels;
using Libreria_Biblioteca_.Areas.Admin.Controllers;
using Libreria_Biblioteca_.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.Slider.GetAll()
            };

            ViewBag.IsHome = true;

            return View(homeVM);
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
