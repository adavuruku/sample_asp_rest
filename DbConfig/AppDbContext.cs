using BookStoreApi.Model; // assuming you have a Book class here
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BookStoreApi.DbConfig
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Book> Books { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder
        //            .UseNpgsql("DefaultConnection")
        //            .UseSnakeCaseNamingConvention(); // 👈 this applies the snake_case
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

           base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().ToTable("books", "public"); // optional if you want lowercase table name
            modelBuilder.Entity<Portfolio>().ToTable("portfolios", "public"); // optional if you want lowercase table name
            modelBuilder.Entity<Comment>().ToTable("comments", "public"); // optional if you want lowercase table name
            modelBuilder.Entity<Stock>().ToTable("stocks", "public"); // optional if you want lowercase table name

            modelBuilder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            modelBuilder.Entity<Portfolio>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.AppUserId);

            modelBuilder.Entity<Portfolio>()
                .HasOne(u => u.Stock)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.StockId);


            List<IdentityRole> roles = new List<IdentityRole>
            {
               new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "admin-role-stamp"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "user-role-stamp"
                },
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
