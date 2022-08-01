using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspWebProjet.Data.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_UnitesPedagogiques_UnitePedagogiqueId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_UnitePedagogiqueId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "UnitePedagogiqueId",
                table: "Modules");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                table: "UnitesPedagogiques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UnitesPedagogiques_ModuleId",
                table: "UnitesPedagogiques",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitesPedagogiques_Modules_ModuleId",
                table: "UnitesPedagogiques",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitesPedagogiques_Modules_ModuleId",
                table: "UnitesPedagogiques");

            migrationBuilder.DropIndex(
                name: "IX_UnitesPedagogiques_ModuleId",
                table: "UnitesPedagogiques");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "UnitesPedagogiques");

            migrationBuilder.AddColumn<int>(
                name: "UnitePedagogiqueId",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_UnitePedagogiqueId",
                table: "Modules",
                column: "UnitePedagogiqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_UnitesPedagogiques_UnitePedagogiqueId",
                table: "Modules",
                column: "UnitePedagogiqueId",
                principalTable: "UnitesPedagogiques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
