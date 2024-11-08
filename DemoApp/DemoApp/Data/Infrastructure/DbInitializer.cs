using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Data.Infrastructure
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole { Id = Guid.Parse("1f92b138-a27e-44cd-904e-7c10eff9616e").ToString(), Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = Guid.Parse("af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5").ToString(), Name = "Student", NormalizedName = "STUDENT" }
            );

            PasswordHasher<ApplicationUser> hasher = new();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Id = "5c817c36-6396-490b-907b-dbe39df82766",
                    UserName = "admin@admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "AdminPass123")
                },
                new ApplicationUser()
                {
                    Id = "8cb4e7ff-0bc8-4def-a918-0a9305c5dd60",
                    UserName = "student@student.com",
                    NormalizedUserName = "STUDENT@STUDENT.COM",
                    Email = "student@student.com",
                    NormalizedEmail = "STUDENT@STUDENT.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "StudentPass123")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "5c817c36-6396-490b-907b-dbe39df82766", RoleId = "1f92b138-a27e-44cd-904e-7c10eff9616e" }, // Admin
                new IdentityUserRole<string> { UserId = "8cb4e7ff-0bc8-4def-a918-0a9305c5dd60", RoleId = "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5" }  // Student
            );
        }
    }
}
