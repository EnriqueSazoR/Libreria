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
    public class UsuarioRepository : Repository<ApplicationUser>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void BloquearUsuario(string IdUsuario)
        {
            var objDesdeBd = _db.ApplicationUsers.FirstOrDefault(u => u.Id ==  IdUsuario);
            objDesdeBd.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void DesbloquearUsuario(string IdUsuario)
        {
            var objDesdeBd = _db.ApplicationUsers.FirstOrDefault(u => u.Id == IdUsuario);
            objDesdeBd.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
