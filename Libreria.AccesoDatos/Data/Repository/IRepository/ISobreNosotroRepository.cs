using Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.AccesoDatos.Data.Repository.IRepository
{
    public interface ISobreNosotroRepository : IRepository<SobreNosotro>
    {
        void Update(SobreNosotro sobreNosotro);
    }
}
