using Microsoft.EntityFrameworkCore;
using WebdotNet.Models;

namespace WebdotNet.Data
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
                new Category { ID = 1, Name = "Action", DisplayOrder = 1 },
                new Category { ID = 2, Name = "Horror", DisplayOrder = 2 },
                new Category { ID = 3, Name = "SciFi", DisplayOrder = 3 },
                new Category { ID = 4, Name = "History", DisplayOrder = 4 },
                new Category { ID = 5, Name = "Comedy", DisplayOrder = 5},
                new Category { ID = 6, Name = "Romance", DisplayOrder = 6 }
            );
        }
    }
}
