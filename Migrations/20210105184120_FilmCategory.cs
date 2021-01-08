using Microsoft.EntityFrameworkCore.Migrations;

namespace Farcas_Viorel_Proiect.Migrations
{
    public partial class FilmCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectorID",
                table: "Film",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FilmCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FilmCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmCategory_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_DirectorID",
                table: "Film",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategory_CategoryID",
                table: "FilmCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmCategory_FilmID",
                table: "FilmCategory",
                column: "FilmID");

            migrationBuilder.AddForeignKey(
                name: "FK_Film_Director_DirectorID",
                table: "Film",
                column: "DirectorID",
                principalTable: "Director",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Film_Director_DirectorID",
                table: "Film");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "FilmCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Film_DirectorID",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                table: "Film");
        }
    }
}
