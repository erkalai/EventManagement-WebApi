using EventManagement.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData
                (
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "admin",
                        PasswordHash = new PasswordHasher<User>().HashPassword(null, "admin123"),
                        Role = "Admin"
                    }
                );
        }

    }
}
