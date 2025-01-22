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
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _db;

        public SliderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Slider slider)
        {
            var ObjDesdeDd = _db.Sliders.FirstOrDefault(x => x.ID == slider.ID);
            ObjDesdeDd.Nombre = slider.Nombre;
            ObjDesdeDd.Estado = slider.Estado;
            ObjDesdeDd.UrlImagen = slider.UrlImagen;
        }
    }
}
