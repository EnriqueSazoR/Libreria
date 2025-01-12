using Libreria.AccesoDatos.Data.Repository.IRepository;
using Libreria.Models;
using Libreria_Biblioteca_.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Libreria.AccesoDatos.Data.Repository
{
    public class SobreNosotroRepository : Repository<SobreNosotro>, ISobreNosotroRepository
    {
        private readonly ApplicationDbContext _db;

        public SobreNosotroRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SobreNosotro sobreNosotro)
        {
            var objDesdeBd = _db.SobreNosotros.FirstOrDefault(x => x.ID == sobreNosotro.ID);
            objDesdeBd.Vision = sobreNosotro.Vision;
            objDesdeBd.Mision = sobreNosotro.Mision;
            objDesdeBd.Informacion = sobreNosotro.Informacion;
        }
    }
}
