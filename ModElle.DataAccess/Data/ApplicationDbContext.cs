using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModElle.Models;

namespace ModElle.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    
        public DbSet<Category> Categories {  get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Jellabas", DisplayOrder = 1 },
            new Category { CategoryId = 2, Name = "Caftans", DisplayOrder = 2 },
            new Category { CategoryId = 3, Name = "Cardigans", DisplayOrder = 3 });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Jellaba",
                    color = "Noir",
                    Description = "Jellaba coupe Mekhzania, tissue crepe de soie 1er ",
                    ListPrice = "499 dh",
                    size = "Taille Standard",
                    CategoryId = 1,
                    ImageUrl=""
                   
                },
                 new Product
                 {
                     Id = 2,
                     Title = "Jellaba",
                     color = "Rose",
                     Description = "Jellaba coupe Normal, tissue crepe de soie 1er ",
                     ListPrice = "499 dh",
                     size = "Taille Standard",
                     CategoryId = 1,
                     ImageUrl = ""



                 },
                  new Product
                  {
                      Id = 3,
                      Title = "Jellaba",
                      color = "Noir",
                      Description = "Jellaba 2 piéces coupe Mekhzania, tissue crepe de soie 1er ",
                      ListPrice = "699 dh",
                      size = "Taille Standard",
                      CategoryId = 2,
                      ImageUrl = ""

                  },
                   new Product
                   {
                       Id = 4,
                       Title = "Jellaba",
                       color = "Noir",
                       Description = "Jellaba coupe Mekhzania, tissue crepe de soie 1er ",
                       ListPrice = "499 dh",
                       size = "Taille Standard",
                       CategoryId = 3,
                       ImageUrl = ""
                   }
                ) ;
        }

    }
}
