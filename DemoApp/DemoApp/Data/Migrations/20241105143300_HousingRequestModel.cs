using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApp.Migrations
{
    /// <inheritdoc />
    public partial class HousingRequestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c817c36-6396-490b-907b-dbe39df82766",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1db3f5a8-85d0-43cb-be70-f0a74776e18c", "AQAAAAIAAYagAAAAEKS8P8aq4Ei2mDeIW8ReXFNV1KKvQt5c5+sE4QnstsAd5OI4R3yeHdqm0X25l8lW0g==", "e33b8485-7459-4868-a505-5d7a386dccbf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8cb4e7ff-0bc8-4def-a918-0a9305c5dd60",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfde292e-906b-40ca-9a9a-f9a31a714190", "AQAAAAIAAYagAAAAEGM+lu4ct/eH0jTMFiJKJdYKQYXYepywlQGe9SUyqgNWtzWvYPFvcDRzExpb9ePf5w==", "cfc07b0c-1fa4-4a77-9ce7-54c8488c5c29" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
