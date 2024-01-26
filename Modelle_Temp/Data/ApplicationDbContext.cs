using Microsoft.EntityFrameworkCore;
using ModElle.Models;
using ModElleRazor_Temp;


namespace ModElleRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Jellabas", DisplayOrder = 1 },
            new Category { Id = 2, Name = "Caftans", DisplayOrder = 2 },
            new Category { Id = 3, Name = "Cardigans", DisplayOrder = 3 });
        }
    }
}
