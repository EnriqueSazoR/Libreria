using Libreria.AccesoDatos.Data.Repository.IRepository;
using Libreria.Models;
using Libreria.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace Libreria_Biblioteca_.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LibrosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public LibrosController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var artiVm = new LibroVM()
            {
                Libro = new Libreria.Models.Libro(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias(),
                ListaAutores = _contenedorTrabajo.Autor.GetListaAutores()
            };

            return View(artiVm);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(LibroVM libroVm)
        {
            if(ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                if(libroVm.Libro.ID == 0 && archivos.Count() > 0)
                {
                    // Genera un nuevo articulo con identificador único
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\libros");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    libroVm.Libro.UrlImagen = @"/imagenes/libros/" + nombreArchivo + extension;

                    _contenedorTrabajo.Libro.Add(libroVm.Libro);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Debes seleccionar una imagen");
                }
            }
            libroVm.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            libroVm.ListaAutores = _contenedorTrabajo.Autor.GetListaAutores();
            return View(libroVm);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var librovM = new LibroVM()
            {
                Libro = new Libreria.Models.Libro(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias(),
                ListaAutores = _contenedorTrabajo.Autor.GetListaAutores()
            };
            if(id != null)
            {
                librovM.Libro = _contenedorTrabajo.Libro.Get(id.GetValueOrDefault());
            }
            return View(librovM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Edit(LibroVM libroVm)
        {
            if(ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var libroDesdeBd = _contenedorTrabajo.Libro.Get(libroVm.Libro.ID);

                if(archivos.Count() > 0)
                {
                    // Nueva imagen para el libro
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\libros");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    if(!string.IsNullOrEmpty(libroDesdeBd?.UrlImagen))
                    {
                        var rutaImagen = Path.Combine(rutaPrincipal, libroDesdeBd.UrlImagen.TrimStart('\\'));

                        if (System.IO.File.Exists(rutaImagen))
                        {
                            System.IO.File.Delete(rutaImagen);
                        }
                    }

                    // se sube archivo nuevamente
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }
                    libroVm.Libro.UrlImagen = @"/imagenes/libros/" + nombreArchivo + extension;

                    _contenedorTrabajo.Libro.Update(libroVm.Libro);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    libroVm.Libro.UrlImagen = libroDesdeBd.UrlImagen;
                }

                _contenedorTrabajo.Libro.Update(libroVm.Libro);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            libroVm.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            libroVm.ListaAutores = _contenedorTrabajo.Autor.GetListaAutores();
            return View(libroVm);
        }


        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Libro.GetAll(includeProperties: "Categoria,Autor") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var libroDesdeBd = _contenedorTrabajo.Libro.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, libroDesdeBd.UrlImagen.TrimStart('\\'));

            if(System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }
            if(libroDesdeBd == null)
            {
                return Json(new { success = false, message = "Error al borrar libro" });
            }
            _contenedorTrabajo.Libro.Remove(libroDesdeBd);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Libro borrado correctamente" });
        }
        #endregion
    }
}
