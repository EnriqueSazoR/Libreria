using Libreria.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.AccesoDatos.Data.Repository.IRepository
{
    public interface IAutorRepository : IRepository<Autor>
    {
        void Upadate(Autor autor);

        IEnumerable<SelectListItem> GetListaAutores();
    }
}
