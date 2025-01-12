using Libreria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Libreria_Biblioteca_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Colocar todos los modelos que se crean
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Autor> Autores { get; set;  }
        public DbSet<SobreNosotro> SobreNosotros { get; set; }
    }
}
