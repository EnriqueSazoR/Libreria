using Libreria.AccesoDatos.Data.Repository.IRepository;
using Libreria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Libreria_Biblioteca_.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AutoresController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnviroment;

        public AutoresController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnviroment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnviroment = hostingEnviroment;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnviroment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                if (archivos.Count() > 0) // Verificar si hay archivos
                {
                    // Nuevo Articulo (genera un identificador unico)
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\autores");

                    // Asegurarse de que la carpeta exista
                    if (!Directory.Exists(subidas))
                    {
                        Directory.CreateDirectory(subidas);
                    }

                    var extension = Path.GetExtension(archivos[0].FileName);

                    // Guardar archivo en el servidor
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    // Guardar la URL del archivo en el modelo
                    autor.UrlImagen = @"\imagenes\autores\" + nombreArchivo + extension;

                    // Guardar el autor
                    _contenedorTrabajo.Autor.Add(autor);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Debes seleccionar una imagen.");
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }
            }

            return View(autor);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Autor autor = new Autor();
            autor = _contenedorTrabajo.Autor.Get(id);
            if(autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Autor autor)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnviroment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var autorDesdeBd = _contenedorTrabajo.Autor.Get(autor.ID);


                if (archivos.Count() > 0)
                {
                    // Nueva imagen para el articulo
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\autores");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, autorDesdeBd.UrlImagen.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    // Nuevamente se sube el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    autor.UrlImagen = @"\imagenes\autores\" + nombreArchivo + extension;

                    _contenedorTrabajo.Autor.Upadate(autor);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    autor.UrlImagen = autorDesdeBd.UrlImagen;
                }

                _contenedorTrabajo.Autor.Upadate(autor);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            
            return View(autor);
        }

        // Traer todos los autores
        [HttpGet]
        public IActionResult informacionAutores()
        {
            var infoAutores = _contenedorTrabajo.Autor.GetAll();
            return View(infoAutores);
        }


        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Autor.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var autorDesdeBd = _contenedorTrabajo.Autor.Get(id);
            string rutaDirectorioPrincipal = _hostingEnviroment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, autorDesdeBd.UrlImagen.TrimStart('\\'));

            if(System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }
            if(autorDesdeBd == null)
            {
                return Json(new { succes = false, message = "Error al eliminar autor" });
            }
            _contenedorTrabajo.Autor.Remove(autorDesdeBd);
            _contenedorTrabajo.Save();
            return Json(new { seccess = true, message = "Autor Eliminado" });
        }
        #endregion
    }
}
