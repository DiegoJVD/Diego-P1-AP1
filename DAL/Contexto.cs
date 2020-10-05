
using Microsoft.EntityFrameworkCore;
using Diego_P1_AP1.Entidades;

namespace Diego_P1_AP1.DAL
{
    public class Context : DbContext{

        public DbSet<Ciudad> Ciudad {get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source=Data/PrimerParcial.db");
        }
    }
}