using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VTPAdmin.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("483c378a-bf29-49e4-a861-d3ab8b828778"), 0, "48a59941-2b6f-4f61-8842-5663721257d4", "superadmin@gmail.com", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEH4EN6wIfEUbO6EggRkAfwkvzbGXN4pSm+j7R5vpd6PlZ/kfF1+owZxauLj1HfZusw==", null, false, "5b8a8da5-1ddf-493d-9ee7-9c1aeb42c9a8", false, "superadmin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("483c378a-bf29-49e4-a861-d3ab8b828778"));
        }
    }
}
