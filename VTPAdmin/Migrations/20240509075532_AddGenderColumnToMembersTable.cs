using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VTPAdmin.Migrations
{
    /// <inheritdoc />
    public partial class AddGenderColumnToMembersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("483c378a-bf29-49e4-a861-d3ab8b828778"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2230a2d-70a8-4b36-a84c-aed16bf08f59", "AQAAAAIAAYagAAAAEJUMg+cGXBBD+g2FvFjG5++qhPkIH+8HI6vcdlEMSo8ORzxXU1IrxVu0p5muzE9Lmw==", "f2364d14-6619-40f9-81bf-c981771131f4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Members");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("483c378a-bf29-49e4-a861-d3ab8b828778"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6643a82e-f5d5-47aa-afb7-6cb57b8243f6", "AQAAAAIAAYagAAAAEJdaHtCaFv7lRBercG3unZe6HenjQKyMBVdqxLp7onUlVIZH9jS/6Sud5zaNd/+RNA==", "dedf1839-0a18-476d-bed5-946945cecc8f" });
        }
    }
}
