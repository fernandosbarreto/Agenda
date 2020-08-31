using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda.Migrations
{
    public partial class ModificandoTipoDeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Entrega",
                table: "Encomendas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Entrega",
                table: "Encomendas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
