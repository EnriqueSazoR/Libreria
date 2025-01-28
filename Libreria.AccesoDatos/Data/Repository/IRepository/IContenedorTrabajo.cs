using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        // Acá se deben agregar los diferentes repositorios
        ICategoriaRepository Categoria { get;  }
        IAutorRepository Autor { get; }
        ISobreNosotroRepository SobreNosotro { get; }
        ILibroRepository Libro { get; }
        ISliderRepository Slider { get; }
        IUsuarioRepository Usuario { get; }
    


        void Save();
    }
}
