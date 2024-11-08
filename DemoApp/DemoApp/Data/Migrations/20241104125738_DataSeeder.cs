using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoApp.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f92b138-a27e-44cd-904e-7c10eff9616e", null, "Admin", "ADMIN" },
                    { "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5c817c36-6396-490b-907b-dbe39df82766", 0, "89a75776-3fe3-48be-8ef2-58b61993441f", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEERz9dDG6Pjc89ahN6J7cqThvtBB2gs13QRIfYUGRTleOc9fOjInqHkAk40o6zNM+w==", null, false, "22562fba-6117-401f-b038-a3869b8bb21d", false, "admin@admin.com" },
                    { "8cb4e7ff-0bc8-4def-a918-0a9305c5dd60", 0, "8ce3d53e-a828-4a73-b6c0-644ce354c0e7", "student@student.com", true, false, null, "STUDENT@STUDENT.COM", "STUDENT@STUDENT.COM", "AQAAAAIAAYagAAAAEBZ1paPWvQ7kurBp325/3HLH1otokGRH7X6bQpiu0QT43LHe0p3xgr84Md5x7AkicA==", null, false, "d560dcd4-3e9f-4db2-9567-18e17664bdf3", false, "student@student.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1f92b138-a27e-44cd-904e-7c10eff9616e", "5c817c36-6396-490b-907b-dbe39df82766" },
                    { "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5", "8cb4e7ff-0bc8-4def-a918-0a9305c5dd60" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1f92b138-a27e-44cd-904e-7c10eff9616e", "5c817c36-6396-490b-907b-dbe39df82766" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5", "8cb4e7ff-0bc8-4def-a918-0a9305c5dd60" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f92b138-a27e-44cd-904e-7c10eff9616e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c817c36-6396-490b-907b-dbe39df82766");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8cb4e7ff-0bc8-4def-a918-0a9305c5dd60");
        }
    }
}
