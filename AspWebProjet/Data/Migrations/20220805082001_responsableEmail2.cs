using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspWebProjet.Data.Migrations
{
    public partial class responsableEmail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Utilisateurs_ResponsableEmail",
                table: "Sessions");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsableEmail",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Utilisateurs_ResponsableEmail",
                table: "Sessions",
                column: "ResponsableEmail",
                principalTable: "Utilisateurs",
                principalColumn: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Utilisateurs_ResponsableEmail",
                table: "Sessions");

            migrationBuilder.AlterColumn<string>(
                name: "ResponsableEmail",
                table: "Sessions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Utilisateurs_ResponsableEmail",
                table: "Sessions",
                column: "ResponsableEmail",
                principalTable: "Utilisateurs",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
