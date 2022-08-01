using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspWebProjet.Data.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeNaissance",
                table: "Utilisateurs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitePedagogiqueId",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UnitePedagogique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitePedagogique", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modules_UnitePedagogiqueId",
                table: "Modules",
                column: "UnitePedagogiqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_UnitePedagogique_UnitePedagogiqueId",
                table: "Modules",
                column: "UnitePedagogiqueId",
                principalTable: "UnitePedagogique",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_UnitePedagogique_UnitePedagogiqueId",
                table: "Modules");

            migrationBuilder.DropTable(
                name: "UnitePedagogique");

            migrationBuilder.DropIndex(
                name: "IX_Modules_UnitePedagogiqueId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "CV",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "DateDeNaissance",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "UnitePedagogiqueId",
                table: "Modules");
        }
    }
}
