using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda.Migrations
{
    public partial class CriandoControllersParaUmaNovaEncomenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Encomendas");

            migrationBuilder.DropColumn(
                name: "IdDoce",
                table: "Encomendas");

            migrationBuilder.DropColumn(
                name: "IdTpDoce",
                table: "Doces");

            migrationBuilder.AlterColumn<int>(
                name: "DoceId",
                table: "Encomendas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Encomendas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TpDoceId",
                table: "Doces",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doces_TpDoces_TpDoceId",
                table: "Doces",
                column: "TpDoceId",
                principalTable: "TpDoces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encomendas_Clientes_ClienteId",
                table: "Encomendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Encomendas_Doces_DoceId",
                table: "Encomendas",
                column: "DoceId",
                principalTable: "Doces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "DoceId",
                table: "Encomendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Encomendas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Encomendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDoce",
                table: "Encomendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TpDoceId",
                table: "Doces",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdTpDoce",
                table: "Doces",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
