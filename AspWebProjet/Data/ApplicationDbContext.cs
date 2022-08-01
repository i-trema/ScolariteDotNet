using AspWebProjet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspWebProjet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Module> Modules { get; set; }
        public DbSet<Parcours> Parcours { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<UnitePedagogique> UnitesPedagogiques { get; set; }
        
    }
}