using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste.Migrations
{
    /// <inheritdoc />
    public partial class AddtablesLivrosLeitoresGenerosLivrosHasGenerosPedidosDeRetiradasandPedidosHasLivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Biblioteca_Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SubGenero = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteca_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biblioteca_Leitores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteca_Leitores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biblioteca_Livros",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Emprestado = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteca_Livros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biblioteca_PedidosHasLivros",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroId = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteca_PedidosHasLivros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biblioteca_PedidosHasLivros_Biblioteca_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Biblioteca_Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilbioteca_LivroHasGenero",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroId = table.Column<long>(type: "bigint", nullable: true),
                    GeneroId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilbioteca_LivroHasGenero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilbioteca_LivroHasGenero_Biblioteca_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Biblioteca_Generos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bilbioteca_LivroHasGenero_Biblioteca_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Biblioteca_Livros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bibliotecas_PedidosDeRetiradas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeRetirada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PedidoHasLivroId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecas_PedidosDeRetiradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bibliotecas_PedidosDeRetiradas_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bibliotecas_PedidosDeRetiradas_Biblioteca_PedidosHasLivros_PedidoHasLivroId",
                        column: x => x.PedidoHasLivroId,
                        principalTable: "Biblioteca_PedidosHasLivros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_PedidosHasLivros_LivroId",
                table: "Biblioteca_PedidosHasLivros",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecas_PedidosDeRetiradas_PedidoHasLivroId",
                table: "Bibliotecas_PedidosDeRetiradas",
                column: "PedidoHasLivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecas_PedidosDeRetiradas_UserId",
                table: "Bibliotecas_PedidosDeRetiradas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilbioteca_LivroHasGenero_GeneroId",
                table: "Bilbioteca_LivroHasGenero",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilbioteca_LivroHasGenero_LivroId",
                table: "Bilbioteca_LivroHasGenero",
                column: "LivroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biblioteca_Leitores");

            migrationBuilder.DropTable(
                name: "Bibliotecas_PedidosDeRetiradas");

            migrationBuilder.DropTable(
                name: "Bilbioteca_LivroHasGenero");

            migrationBuilder.DropTable(
                name: "Biblioteca_PedidosHasLivros");

            migrationBuilder.DropTable(
                name: "Biblioteca_Generos");

            migrationBuilder.DropTable(
                name: "Biblioteca_Livros");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "AbpUsers");
        }
    }
}
