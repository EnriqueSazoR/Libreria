using Libreria.AccesoDatos.Data.Repository.IRepository;
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


        #region
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            return Json(new { data = _contenedorTrabajo.SobreNosotro.GetAll() });
        }
        #endregion
    }
}
