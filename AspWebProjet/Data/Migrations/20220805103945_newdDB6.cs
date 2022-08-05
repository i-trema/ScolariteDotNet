using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspWebProjet.Data.Migrations
{
    public partial class newdDB6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UtilisateurEmail",
                table: "Modules",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_UtilisateurEmail",
                table: "Modules",
                column: "UtilisateurEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Utilisateurs_UtilisateurEmail",
                table: "Modules",
                column: "UtilisateurEmail",
                principalTable: "Utilisateurs",
                principalColumn: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Utilisateurs_UtilisateurEmail",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_UtilisateurEmail",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "UtilisateurEmail",
                table: "Modules");
        }
    }
}
