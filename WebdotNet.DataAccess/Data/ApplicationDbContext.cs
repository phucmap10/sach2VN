using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebdotNet.Models;

namespace WebdotNet.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //this is needed when we use IdentityDbContext
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Action", DisplayOrder = 1 },
                new Category { ID = 2, Name = "Horror", DisplayOrder = 2 },
                new Category { ID = 3, Name = "SciFi", DisplayOrder = 3 },
                new Category { ID = 4, Name = "History", DisplayOrder = 4 },
                new Category { ID = 5, Name = "Comedy", DisplayOrder = 5 },
                new Category { ID = 6, Name = "Romance", DisplayOrder = 6 }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products { ID = 1, Title = "The Hunger Games", Description = "A dystopian novel set in a post-apocalyptic world.", Author = "Suzanne Collins", ISBN = "9780439023481", ListPrice = 10.99, Price = 9.99, Price50 = 8.99, Price100 = 7.99, Category = "Action", imgUrl = "" },
                new Products { ID = 2, Title = "Dracula", Description = "A horror novel about the vampire Count Dracula.", Author = "Bram Stoker", ISBN = "9780141439846", ListPrice = 8.99, Price = 7.99, Price50 = 6.99, Price100 = 5.99, Category = "Horror", imgUrl = "" },
                new Products { ID = 3, Title = "Dune", Description = "A science fiction novel set in a distant future amidst a huge interstellar empire.", Author = "Frank Herbert", ISBN = "9780441013593", ListPrice = 9.99, Price = 8.99, Price50 = 7.99, Price100 = 6.99, Category = "SciFi", imgUrl = "" },
                new Products { ID = 4, Title = "Sapiens", Description = "A brief history of humankind.", Author = "Yuval Noah Harari", ISBN = "9780062316097", ListPrice = 14.99, Price = 13.99, Price50 = 12.99, Price100 = 11.99, Category = "History", imgUrl = "" },
                new Products { ID = 5, Title = "Bossypants", Description = "A comedy memoir by Tina Fey.", Author = "Tina Fey", ISBN = "9780316056892", ListPrice = 12.99, Price = 11.99, Price50 = 10.99, Price100 = 9.99, Category = "Comedy", imgUrl = "" },
                new Products { ID = 6, Title = "Pride and Prejudice", Description = "A romance novel by Jane Austen.", Author = "Jane Austen", ISBN = "9780141040349", ListPrice = 7.99, Price = 6.99, Price50 = 5.99, Price100 = 4.99, Category = "Romance", imgUrl = "" },
                new Products { ID = 7, Title = "Catching Fire", Description = "The second book in The Hunger Games series.", Author = "Suzanne Collins", ISBN = "9780439023498", ListPrice = 10.99, Price = 9.99, Price50 = 8.99, Price100 = 7.99, Category = "Action", imgUrl = "" },
                new Products { ID = 8, Title = "Frankenstein", Description = "A horror novel about a scientist who creates a monster.", Author = "Mary Shelley", ISBN = "9780141439471", ListPrice = 8.99, Price = 7.99, Price50 = 6.99, Price100 = 5.99, Category = "Horror", imgUrl = "" },
                new Products { ID = 9, Title = "Neuromancer", Description = "A science fiction novel that tells the story of a washed-up computer hacker.", Author = "William Gibson", ISBN = "9780441569595", ListPrice = 9.99, Price = 8.99, Price50 = 7.99, Price100 = 6.99, Category = "SciFi", imgUrl = "" },
                new Products { ID = 10, Title = "Guns, Germs, and Steel", Description = "A history book that explores the factors that contributed to the development of human societies.", Author = "Jared Diamond", ISBN = "9780393354324", ListPrice = 14.99, Price = 13.99, Price50 = 12.99, Price100 = 11.99, Category = "History", imgUrl = "" }
            );
        }
    }
}