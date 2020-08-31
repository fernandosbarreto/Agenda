using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda.Migrations
{
    public partial class AlterandoValoresParaString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Quantidade",
                table: "Encomendas",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Preco",
                table: "Encomendas",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Clientes",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Clientes",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 13);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Encomendas",
                type: "int",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Encomendas",
                type: "float",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Clientes",
                type: "int",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Celular",
                table: "Clientes",
                type: "int",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 13,
                oldNullable: true);
        }
    }
}
