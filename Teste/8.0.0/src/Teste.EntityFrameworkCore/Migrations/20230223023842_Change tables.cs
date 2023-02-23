using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste.Migrations
{
    /// <inheritdoc />
    public partial class Changetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecas_PedidosDeRetiradas_AbpUsers_UserId",
                table: "Bibliotecas_PedidosDeRetiradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecas_PedidosDeRetiradas_Biblioteca_PedidosHasLivros_PedidoHasLivroId",
                table: "Bibliotecas_PedidosDeRetiradas");

            migrationBuilder.DropTable(
                name: "Biblioteca_Leitores");

            migrationBuilder.DropTable(
                name: "Biblioteca_PedidosHasLivros");

            migrationBuilder.DropTable(
                name: "Bilbioteca_LivroHasGenero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bibliotecas_PedidosDeRetiradas",
                table: "Bibliotecas_PedidosDeRetiradas");

            migrationBuilder.DropIndex(
                name: "IX_Bibliotecas_PedidosDeRetiradas_PedidoHasLivroId",
                table: "Bibliotecas_PedidosDeRetiradas");

            migrationBuilder.DropColumn(
                name: "DataDeDevolucao",
                table: "Bibliotecas_PedidosDeRetiradas");

            migrationBuilder.DropColumn(
                name: "PedidoHasLivroId",
                table: "Bibliotecas_PedidosDeRetiradas");

            migrationBuilder.RenameTable(
                name: "Bibliotecas_PedidosDeRetiradas",
                newName: "Bibliotecas_PedidosDeRetiradasItens");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Biblioteca_Livros",
                newName: "Nome_Livro");

            migrationBuilder.RenameColumn(
                name: "Emprestado",
                table: "Biblioteca_Livros",
                newName: "Disponivel");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Biblioteca_Generos",
                newName: "Nome_Genero");

            migrationBuilder.RenameIndex(
                name: "IX_Bibliotecas_PedidosDeRetiradas_UserId",
                table: "Bibliotecas_PedidosDeRetiradasItens",
                newName: "IX_Bibliotecas_PedidosDeRetiradasItens_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Biblioteca_Livros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SubGenero",
                table: "Biblioteca_Generos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<long>(
                name: "LivroId",
                table: "Biblioteca_Generos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Bibliotecas_PedidosDeRetiradasItens",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusPedido",
                table: "Bibliotecas_PedidosDeRetiradasItens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bibliotecas_PedidosDeRetiradasItens",
                table: "Bibliotecas_PedidosDeRetiradasItens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Biblioteca_PedidosDeRetiradaItens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivroId = table.Column<long>(type: "bigint", nullable: false),
                    PedidoDeRetiradaId = table.Column<long>(type: "bigint", nullable: false),
                    DataDeDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Biblioteca_PedidosDeRetiradaItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biblioteca_PedidosDeRetiradaItens_Biblioteca_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Biblioteca_Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Biblioteca_PedidosDeRetiradaItens_Bibliotecas_PedidosDeRetiradasItens_PedidoDeRetiradaId",
                        column: x => x.PedidoDeRetiradaId,
                        principalTable: "Bibliotecas_PedidosDeRetiradasItens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_Generos_LivroId",
                table: "Biblioteca_Generos",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_PedidosDeRetiradaItens_LivroId",
                table: "Biblioteca_PedidosDeRetiradaItens",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_PedidosDeRetiradaItens_PedidoDeRetiradaId",
                table: "Biblioteca_PedidosDeRetiradaItens",
                column: "PedidoDeRetiradaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Biblioteca_Generos_Biblioteca_Livros_LivroId",
                table: "Biblioteca_Generos",
                column: "LivroId",
                principalTable: "Biblioteca_Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotecas_PedidosDeRetiradasItens_AbpUsers_UserId",
                table: "Bibliotecas_PedidosDeRetiradasItens",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biblioteca_Generos_Biblioteca_Livros_LivroId",
                table: "Biblioteca_Generos");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecas_PedidosDeRetiradasItens_AbpUsers_UserId",
                table: "Bibliotecas_PedidosDeRetiradasItens");

            migrationBuilder.DropTable(
                name: "Biblioteca_PedidosDeRetiradaItens");

            migrationBuilder.DropIndex(
                name: "IX_Biblioteca_Generos_LivroId",
                table: "Biblioteca_Generos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bibliotecas_PedidosDeRetiradasItens",
                table: "Bibliotecas_PedidosDeRetiradasItens");

            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Biblioteca_Livros");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "Biblioteca_Generos");

            migrationBuilder.DropColumn(
                name: "StatusPedido",
                table: "Bibliotecas_PedidosDeRetiradasItens");

            migrationBuilder.RenameTable(
                name: "Bibliotecas_PedidosDeRetiradasItens",
                newName: "Bibliotecas_PedidosDeRetiradas");

            migrationBuilder.RenameColumn(
                name: "Nome_Livro",
                table: "Biblioteca_Livros",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Disponivel",
                table: "Biblioteca_Livros",
                newName: "Emprestado");

            migrationBuilder.RenameColumn(
                name: "Nome_Genero",
                table: "Biblioteca_Generos",
                newName: "Nome");

            migrationBuilder.RenameIndex(
                name: "IX_Bibliotecas_PedidosDeRetiradasItens_UserId",
                table: "Bibliotecas_PedidosDeRetiradas",
                newName: "IX_Bibliotecas_PedidosDeRetiradas_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "SubGenero",
                table: "Biblioteca_Generos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Bibliotecas_PedidosDeRetiradas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeDevolucao",
                table: "Bibliotecas_PedidosDeRetiradas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "PedidoHasLivroId",
                table: "Bibliotecas_PedidosDeRetiradas",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bibliotecas_PedidosDeRetiradas",
                table: "Bibliotecas_PedidosDeRetiradas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Biblioteca_Leitores",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteca_Leitores", x => x.Id);
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
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
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
                    GeneroId = table.Column<int>(type: "int", nullable: true),
                    LivroId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecas_PedidosDeRetiradas_PedidoHasLivroId",
                table: "Bibliotecas_PedidosDeRetiradas",
                column: "PedidoHasLivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Biblioteca_PedidosHasLivros_LivroId",
                table: "Biblioteca_PedidosHasLivros",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilbioteca_LivroHasGenero_GeneroId",
                table: "Bilbioteca_LivroHasGenero",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilbioteca_LivroHasGenero_LivroId",
                table: "Bilbioteca_LivroHasGenero",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotecas_PedidosDeRetiradas_AbpUsers_UserId",
                table: "Bibliotecas_PedidosDeRetiradas",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliotecas_PedidosDeRetiradas_Biblioteca_PedidosHasLivros_PedidoHasLivroId",
                table: "Bibliotecas_PedidosDeRetiradas",
                column: "PedidoHasLivroId",
                principalTable: "Biblioteca_PedidosHasLivros",
                principalColumn: "Id");
        }
    }
}
