using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonneAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedPersonneTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Personne",
                columns: new[] { "Id", "BirthDay", "CreateDate", "FirstName", "LastName", "UpdateDate" },
                values: new object[] { 1, new DateTime(1991, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 26, 10, 18, 20, 344, DateTimeKind.Local).AddTicks(116), "Khaled", "Mejri", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personne",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
