using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task2.Models;

namespace Task2.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=users.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Пример: явное указание имени таблицы
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Login = "Sveta", Age = 21, Name = "Светка", PasswordHash = "$2a$11$dO/Tt75yvA2mJDMKoHggHeVF8aXHwoQ2przX1Q6BYTAkm6dALN7mS", RoleId = 1 }, //sveta2004
                new User { Id = 2, Login = "Lena", Age = 22, Name = "Ленка", PasswordHash = "$2a$11$WpATXfS2VWTrHIXUjY3KUevA0ZYtLLMeeaPkOX52uhtQhuOTRoIsO", RoleId = 2 }, //lenaP0Jl()()
                new User { Id = 3, Login = "Vika", Age = 23, Name = "Вика", PasswordHash = "$2a$11$4alJjevdQJ6eIIxtT3Hh/uEaGmMRUB4XVhGAPjJgLO3.LfgDYgW/u", RoleId = 3 } //vikSergeevna17
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "User"},
                new Role { Id = 2, Name = "Manager" },
                new Role { Id = 3, Name = "Admin" }
            );

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role);
        }
    }
}
