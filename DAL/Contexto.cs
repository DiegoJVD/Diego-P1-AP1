
using Microsoft.EntityFrameworkCore;

namespace RegistroPrestamos.DAL
{
    public class Context : DbContext{
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source=Data/PrimerParcial.db");
        }
    }
}