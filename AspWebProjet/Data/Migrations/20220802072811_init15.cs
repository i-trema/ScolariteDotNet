using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspWebProjet.Data.Migrations
{
    public partial class init15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sessions",
                newName: "DateDebut");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFin",
                table: "Sessions",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFin",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "DateDebut",
                table: "Sessions",
                newName: "Date");
        }
    }
}
