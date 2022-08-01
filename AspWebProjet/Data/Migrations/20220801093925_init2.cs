using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspWebProjet.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Infos",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ParcoursId",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Parcours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcours", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modules_ParcoursId",
                table: "Modules",
                column: "ParcoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Parcours_ParcoursId",
                table: "Modules",
                column: "ParcoursId",
                principalTable: "Parcours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Parcours_ParcoursId",
                table: "Modules");

            migrationBuilder.DropTable(
                name: "Parcours");

            migrationBuilder.DropIndex(
                name: "IX_Modules_ParcoursId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Infos",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ParcoursId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Resume",
                table: "Modules");
        }
    }
}
