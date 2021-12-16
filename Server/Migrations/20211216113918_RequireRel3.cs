using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    public partial class RequireRel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrade_AspNetUsers_UserId",
                table: "StudentGrade");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f9fcf97-62fb-4962-9800-cae72cd7ade3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80232100-9ab5-4d79-9e0e-990a6e6eb0ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae885aa3-095c-4636-8983-6e059dfbcde7");

            migrationBuilder.UpdateData(
                table: "StudentGrade",
                keyColumn: "UserId",
                keyValue: null,
                column: "UserId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "StudentGrade",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99fd7858-80ec-426f-a54e-162ba77ea9d5", "86048dff-e68c-4aec-94ca-6887d1e4c674", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0c8ebbb-e962-4424-9c55-81af52711b24", "f2f44ab0-7086-4be9-bd55-e9ce372030cc", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd57b5f8-b4e7-4de9-923f-b408caa028f3", "faf67822-9180-434c-8b38-9d9419a6fb15", "Lecturer", "LECTURER" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrade_AspNetUsers_UserId",
                table: "StudentGrade",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGrade_AspNetUsers_UserId",
                table: "StudentGrade");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99fd7858-80ec-426f-a54e-162ba77ea9d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0c8ebbb-e962-4424-9c55-81af52711b24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd57b5f8-b4e7-4de9-923f-b408caa028f3");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "StudentGrade",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f9fcf97-62fb-4962-9800-cae72cd7ade3", "9a771505-3988-4817-938b-742226c8adb1", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "80232100-9ab5-4d79-9e0e-990a6e6eb0ec", "96f0ffd9-b0b6-4bfd-9b38-e54bd818b450", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae885aa3-095c-4636-8983-6e059dfbcde7", "e66d1573-b461-474d-9896-6b585de5e079", "Lecturer", "LECTURER" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGrade_AspNetUsers_UserId",
                table: "StudentGrade",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
