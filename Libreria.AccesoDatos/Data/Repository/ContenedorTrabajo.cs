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
    public class ContenedorTrabajo : IContenedorTrabajo
    {

        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;

            // Se llaman a todos los repositorios para que estén encapsulados
            Categoria = new CategoriaRepository(_db);
            Autor = new AutorRepository(_db);
            SobreNosotro = new SobreNosotroRepository(_db);
            Libro = new LibroRepository(_db);
            Slider = new SliderRepository(_db);
            Usuario = new UsuarioRepository(_db);

        }

        public ICategoriaRepository Categoria { get; private set; }
        public IAutorRepository Autor { get; private set; }
        public ISobreNosotroRepository SobreNosotro { get; private set; }
        public ILibroRepository Libro { get; private set; }
        public ISliderRepository Slider { get; private set; }
        public IUsuarioRepository Usuario { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
