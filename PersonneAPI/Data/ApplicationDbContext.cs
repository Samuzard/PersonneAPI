using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PersonneAPI.Model;

namespace PersonneAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Personne> Personne { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>().HasData(
                new Personne {
                    Id = 1,
                    FirstName = "Khaled",
                    LastName = "Mejri",
                    BirthDay = new DateTime(1991,03,18),
                    CreateDate = DateTime.Now
                }
            );
        }
    }
}
