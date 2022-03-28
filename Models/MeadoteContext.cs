using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Meadote.Models
{
    public class MeadoteContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                   
            optionsBuilder.UseMySql("Server=localhost;DataBase=Meadote;Uid=root;");
        }

        public DbSet<Adocao> Adocaos {get; set;}
        public DbSet<Fale> Fales {get; set;}

        public DbSet<Voluntario> Voluntarios {get; set;}

    }
}
