using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspWebProjet.Data.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_UnitePedagogique_UnitePedagogiqueId",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitePedagogique",
                table: "UnitePedagogique");

            migrationBuilder.RenameTable(
                name: "UnitePedagogique",
                newName: "UnitesPedagogiques");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitesPedagogiques",
                table: "UnitesPedagogiques",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_UnitesPedagogiques_UnitePedagogiqueId",
                table: "Modules",
                column: "UnitePedagogiqueId",
                principalTable: "UnitesPedagogiques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_UnitesPedagogiques_UnitePedagogiqueId",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitesPedagogiques",
                table: "UnitesPedagogiques");

            migrationBuilder.RenameTable(
                name: "UnitesPedagogiques",
                newName: "UnitePedagogique");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitePedagogique",
                table: "UnitePedagogique",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_UnitePedagogique_UnitePedagogiqueId",
                table: "Modules",
                column: "UnitePedagogiqueId",
                principalTable: "UnitePedagogique",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
