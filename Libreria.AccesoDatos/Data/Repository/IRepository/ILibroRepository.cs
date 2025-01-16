using Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.AccesoDatos.Data.Repository.IRepository
{
    public interface ILibroRepository : IRepository<Libro>
    {
        void Update(Libro libro);

        // Método para buscar
        IQueryable<Libro> AsQuerable();
    }
}
