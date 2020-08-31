using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda.Migrations
{
    public partial class CriandoControllers_e_TelaDeEncomenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTpDoce",
                table: "Encomendas");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Encomendas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoceId",
                table: "Encomendas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TpDoceId",
                table: "Doces",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Encomendas_ClienteId",
                table: "Encomendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Encomendas_DoceId",
                table: "Encomendas",
                column: "DoceId");

            migrationBuilder.CreateIndex(
                name: "IX_Doces_TpDoceId",
                table: "Doces",
                column: "TpDoceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doces_TpDoces_TpDoceId",
                table: "Doces",
                column: "TpDoceId",
                principalTable: "TpDoces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Encomendas_Clientes_ClienteId",
                table: "Encomendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Encomendas_Doces_DoceId",
                table: "Encomendas",
                column: "DoceId",
                principalTable: "Doces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doces_TpDoces_TpDoceId",
                table: "Doces");

            migrationBuilder.DropForeignKey(
                name: "FK_Encomendas_Clientes_ClienteId",
                table: "Encomendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Encomendas_Doces_DoceId",
                table: "Encomendas");

            migrationBuilder.DropIndex(
                name: "IX_Encomendas_ClienteId",
                table: "Encomendas");

            migrationBuilder.DropIndex(
                name: "IX_Encomendas_DoceId",
                table: "Encomendas");

            migrationBuilder.DropIndex(
                name: "IX_Doces_TpDoceId",
                table: "Doces");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Encomendas");

            migrationBuilder.DropColumn(
                name: "DoceId",
                table: "Encomendas");

            migrationBuilder.DropColumn(
                name: "TpDoceId",
                table: "Doces");

            migrationBuilder.AddColumn<int>(
                name: "IdTpDoce",
                table: "Encomendas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
