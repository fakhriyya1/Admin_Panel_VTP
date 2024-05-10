using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VTPAdmin.Migrations
{
    /// <inheritdoc />
    public partial class AddEventPlaceColumnToEventsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventPlace",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("483c378a-bf29-49e4-a861-d3ab8b828778"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e8463d2-23f2-42af-bda7-828662a02f3b", "AQAAAAIAAYagAAAAEH9SPEeY9soVuGgfdVoeZ+0JA629HQHCRiH9F/GTiPIZF0QA3nssDFZLA5g26pOwKQ==", "380b409f-cfbd-4cb2-bc3f-d687bbbb736a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventPlace",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("483c378a-bf29-49e4-a861-d3ab8b828778"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19638a2b-485c-488d-9734-1d5e2573b7bb", "AQAAAAIAAYagAAAAEKmMfhpgB+xwSUmm50eFvNfzNHUzXWzOWiEDGLAsypf+HfCj/JKJipFIZcISK1z8GA==", "e74c6819-8dc7-4bac-bbb3-82f4b7492838" });
        }
    }
}
