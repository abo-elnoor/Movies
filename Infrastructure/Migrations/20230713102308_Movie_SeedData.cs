using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Movie_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cast",
                columns: new[] { "Id", "CastOrder", "CharGender", "CharName", "MovieId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 'F', "Cast1", 1, 3 },
                    { 2, 1, 'M', "Cast2", 1, 4 },
                    { 3, 2, 'F', "Cast3", 1, 5 },
                    { 4, 1, 'F', "Cast4", 2, 6 },
                    { 5, 2, 'M', "Cast5", 2, 7 },
                    { 6, 3, 'M', "Cast6", 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 'F', "Director1" },
                    { 2, 'M', "Director2" },
                    { 3, 'F', "Person3" },
                    { 4, 'M', "Person4" },
                    { 5, 'M', "Person5" },
                    { 6, 'F', "Person6" },
                    { 7, 'M', "Person7" },
                    { 8, 'M', "Person8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cast",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cast",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cast",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cast",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cast",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cast",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
