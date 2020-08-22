using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agenda.Migrations
{
    public partial class CriandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Sobrenome = table.Column<string>(maxLength: 200, nullable: true),
                    Telefone = table.Column<int>(maxLength: 11, nullable: false),
                    Celular = table.Column<int>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    Endereco = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTpDoce = table.Column<int>(nullable: false),
                    Sabor = table.Column<string>(maxLength: 100, nullable: true),
                    Preco = table.Column<double>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encomendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    IdDoce = table.Column<int>(nullable: false),
                    IdTpDoce = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(maxLength: 4, nullable: false),
                    Preco = table.Column<double>(maxLength: 10, nullable: false),
                    Entrega = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encomendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TpDoces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TpDoces", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Doces");

            migrationBuilder.DropTable(
                name: "Encomendas");

            migrationBuilder.DropTable(
                name: "TpDoces");

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_PessoaId",
                table: "Telefones",
                column: "PessoaId");
        }
    }
}
