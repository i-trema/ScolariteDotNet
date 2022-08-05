using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspWebProjet.Data.Migrations
{
    public partial class newdDB11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PanierUtilisateurEmail",
                table: "Modules",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Paniers",
                columns: table => new
                {
                    UtilisateurEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paniers", x => x.UtilisateurEmail);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modules_PanierUtilisateurEmail",
                table: "Modules",
                column: "PanierUtilisateurEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Paniers_PanierUtilisateurEmail",
                table: "Modules",
                column: "PanierUtilisateurEmail",
                principalTable: "Paniers",
                principalColumn: "UtilisateurEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Paniers_PanierUtilisateurEmail",
                table: "Modules");

            migrationBuilder.DropTable(
                name: "Paniers");

            migrationBuilder.DropIndex(
                name: "IX_Modules_PanierUtilisateurEmail",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "PanierUtilisateurEmail",
                table: "Modules");
        }
    }
}
