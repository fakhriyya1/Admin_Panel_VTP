using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VTPAdmin.Migrations
{
    /// <inheritdoc />
    public partial class AddGuestColumnToEventsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Guest",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("483c378a-bf29-49e4-a861-d3ab8b828778"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19638a2b-485c-488d-9734-1d5e2573b7bb", "AQAAAAIAAYagAAAAEKmMfhpgB+xwSUmm50eFvNfzNHUzXWzOWiEDGLAsypf+HfCj/JKJipFIZcISK1z8GA==", "e74c6819-8dc7-4bac-bbb3-82f4b7492838" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guest",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("483c378a-bf29-49e4-a861-d3ab8b828778"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2230a2d-70a8-4b36-a84c-aed16bf08f59", "AQAAAAIAAYagAAAAEJUMg+cGXBBD+g2FvFjG5++qhPkIH+8HI6vcdlEMSo8ORzxXU1IrxVu0p5muzE9Lmw==", "f2364d14-6619-40f9-81bf-c981771131f4" });
        }
    }
}
