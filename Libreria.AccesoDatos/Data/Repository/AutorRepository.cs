using Libreria.AccesoDatos.Data.Repository.IRepository;
using Libreria.Models;
using Libreria_Biblioteca_.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.AccesoDatos.Data.Repository
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {

        private readonly ApplicationDbContext _db;

        public AutorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaAutores()
        {
            return _db.Autores.Select(i => new SelectListItem()
            {
                Text = i.NombreAutor,
                Value = i.ID.ToString()
            });
        }

        public void Upadate(Autor autor)
        {
            var objDesdeBd = _db.Autores.FirstOrDefault(x => x.ID == autor.ID);
            objDesdeBd.NombreAutor = autor.NombreAutor;
            objDesdeBd.Biografia = autor.Biografia;
            objDesdeBd.UrlImagen = autor.UrlImagen;
        }
    }
}
