using Libreria.AccesoDatos.Data.Repository.IRepository;
using Libreria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_Biblioteca_.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SobreNosotrosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public SobreNosotrosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            SobreNosotro nosotro = new SobreNosotro();
            nosotro = _contenedorTrabajo.SobreNosotro.Get(id);
            if(nosotro == null)
            {
                return NotFound();
            }
            return View(nosotro);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(SobreNosotro nosotros)
        {
            if (ModelState.IsValid)
            {
                nosotros.FechaActualizacion = DateTime.Now;
                _contenedorTrabajo.SobreNosotro.Update(nosotros);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(nosotros);
        }

        // Metodo para obtener los datos guardados para mostrarlos en la vista Sobre Nosotros del cliente
        [HttpGet]
        public IActionResult SobreNosotros()
        {
            var nosotros = _contenedorTrabajo.SobreNosotro.GetFirstOrDefault();

            return View(nosotros);
        }


        #region
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            return Json(new { data = _contenedorTrabajo.SobreNosotro.GetAll() });
        }
        #endregion
    }
}
