using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class RequireRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "004f0b5d-4985-4073-a3cc-de16be8a8bb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64eb0ae6-43d6-43c5-82c8-9417b9ea76eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da35524e-9ed2-4abf-a90e-ee01aec350f3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "004f0b5d-4985-4073-a3cc-de16be8a8bb5", "63365d83-9898-4023-b002-25ffb5cc6bd3", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64eb0ae6-43d6-43c5-82c8-9417b9ea76eb", "3b0e9976-49b3-4527-a31b-0f339f0e42b5", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da35524e-9ed2-4abf-a90e-ee01aec350f3", "306fd729-26bc-418f-adf2-b4acec23829c", "Lecturer", "LECTURER" });
        }
    }
}
