using DemoApp.Data.Infrastructure;
using DemoApp.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly string? _connectionString;

        public ApplicationDbContext(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder opBuilder)
        {
            if (_connectionString != null)
                opBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Dorm> Dorms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<HousingRequest> HousingRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}
