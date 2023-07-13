using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CharName = table.Column<string>(type: "TEXT", nullable: false),
                    CastOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    CharGender = table.Column<char>(type: "TEXT", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DirectorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<char>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

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
                table: "Movie",
                columns: new[] { "Id", "DirectorId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Movie1" },
                    { 2, 2, "Movie2" }
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
            migrationBuilder.DropTable(
                name: "Cast");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
