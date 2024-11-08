using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApp.Migrations
{
    /// <inheritdoc />
    public partial class FacultyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyId);
                });

            migrationBuilder.CreateTable(
                name: "HousingRequests",
                columns: table => new
                {
                    HousingRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HousingStart = table.Column<DateOnly>(type: "date", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingRequests", x => x.HousingRequestId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c817c36-6396-490b-907b-dbe39df82766",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33effe1a-80ad-4cc5-83f9-0eac5c23753e", "AQAAAAIAAYagAAAAEDeDz1iS1NxlCeCJ47JAiVY+sRjAafZx2uKZWnTLHbm2Ukr6d12HpM6o6mTchZ8nCA==", "af8de305-c74e-41de-8da2-6eecf3e7eb43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8cb4e7ff-0bc8-4def-a918-0a9305c5dd60",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f20ee49b-86f9-4764-ba43-33d932f512b5", "AQAAAAIAAYagAAAAEAVyEdK2qEm9/Q+aEBEDFxMExi4b+4rs/dI2slzKeFKg5qJC/RumIGZ10qfiQmmPKQ==", "e92a9c8f-c090-4a5f-a88b-6288860d2d95" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "HousingRequests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c817c36-6396-490b-907b-dbe39df82766",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89a75776-3fe3-48be-8ef2-58b61993441f", "AQAAAAIAAYagAAAAEERz9dDG6Pjc89ahN6J7cqThvtBB2gs13QRIfYUGRTleOc9fOjInqHkAk40o6zNM+w==", "22562fba-6117-401f-b038-a3869b8bb21d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8cb4e7ff-0bc8-4def-a918-0a9305c5dd60",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ce3d53e-a828-4a73-b6c0-644ce354c0e7", "AQAAAAIAAYagAAAAEBZ1paPWvQ7kurBp325/3HLH1otokGRH7X6bQpiu0QT43LHe0p3xgr84Md5x7AkicA==", "d560dcd4-3e9f-4db2-9567-18e17664bdf3" });
        }
    }
}
