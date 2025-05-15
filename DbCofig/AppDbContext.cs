using Microsoft.EntityFrameworkCore;
using BookStoreApi.Model; // assuming you have a Book class here

namespace BookStoreApi.DbConfig
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseNpgsql("DefaultConnection")
                    .UseSnakeCaseNamingConvention(); // 👈 this applies the snake_case
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("books", "public"); // optional if you want lowercase table name
        }
    }
}
