using EventManagement.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Billing> Billing { get; set; }
        public DbSet<Client> Clients { get; set; }  
        public DbSet<EventResource> EventResources { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<EventStaff> EventStaffs { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>().HasData
            //    (
            //        new User
            //        {
            //            Id = Guid.NewGuid(),
            //            Username = "admin",
            //            PasswordHash = new PasswordHasher<User>().HashPassword(null, "admin123"),
            //            Role = "Admin"
            //        }
            //    );

            //modelBuilder.Entity<EventStaff>()
            //    .HasOne(es => es.Event)
            //    .WithMany(e => e.EventStaffs)
            //    .HasForeignKey(es => es.EventId);

            //modelBuilder.Entity<EventStaff>()
            //    .HasOne(es => es.Staff)
            //    .WithMany(s => s.EventStaffs)
            //    .HasForeignKey(es => es.StaffId);

            //modelBuilder.Entity<EventResource>()
            //    .HasOne(er => er.Event)
            //    .WithMany(e => e.EventResources)
            //    .HasForeignKey(er => er.EventId);   

            //modelBuilder.Entity<EventResource>()
            //    .HasOne(er => er.Resource)
            //    .WithMany(r => r.EventResources)
            //    .HasForeignKey(er => er.ResourceId);
        }

    }
}
