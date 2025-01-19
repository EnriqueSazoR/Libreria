using Libreria.AccesoDatos.Data.Repository.IRepository;
using Libreria.Models;
using Libreria_Biblioteca_.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.AccesoDatos.Data.Repository
{
    public class LibroRepository: Repository<Libro>, ILibroRepository
    {
        private readonly ApplicationDbContext _db;
        public LibroRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public IQueryable<Libro> AsQuerable()
        {
            return _db.Set<Libro>().AsQueryable();
        }

        public void Update(Libro libro)
        {
            var objDesdeDb = _db.Libros.FirstOrDefault(x => x.ID == libro.ID);

            if (objDesdeDb != null)
            {
                objDesdeDb.NombreLibro = libro.NombreLibro;
                objDesdeDb.Sinopsis = libro.Sinopsis;
                objDesdeDb.NumeroPaginas = libro.NumeroPaginas;
                objDesdeDb.UrlImagen = libro.UrlImagen;
                objDesdeDb.IdCategoria = libro.IdCategoria;
                objDesdeDb.IdAutor = libro.IdAutor;
            }
            else
            {
                // Manejo cuando no se encuentra el libro
                throw new InvalidOperationException($"El libro con ID {libro.ID} no existe en la base de datos.");
            }
        }

    }
}
