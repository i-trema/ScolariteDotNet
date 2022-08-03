using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspWebProjet.Data.Migrations
{
    public partial class listeEtudiants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Utilisateurs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_SessionId",
                table: "Utilisateurs",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Sessions_SessionId",
                table: "Utilisateurs",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Sessions_SessionId",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_SessionId",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Utilisateurs");
        }
    }
}
