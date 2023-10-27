using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Admin" },
                new Role { RoleId = 2, Name = "User" }
            );

            // Seed users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1,Name = "Admin", Email="admin@gmail.com", Password="Admin@123",RoleId=1},
                new User { UserId = 2,Name = "Jayesh Gangurde", Email="admin@gmail.com", Password="Admin@123", RoleId = 2 }
            );

            // Assign roles to users
            //modelBuilder.Entity<IdentityUserRole<int>>().HasData(
            //    new IdentityUserRole<int> { UserId = 1, RoleId = 1 }, // User with Id 1 is an Admin
            //    new IdentityUserRole<int> { UserId = 2, RoleId = 2 }  // User with Id 2 is a User
            //);
        }
    }

}
