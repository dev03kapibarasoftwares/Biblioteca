using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste.Migrations
{
    /// <inheritdoc />
    public partial class Changetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biblioteca_PedidosDeRetiradaItens_Bibliotecas_PedidosDeRetiradasItens_PedidoDeRetiradaId",
                table: "Biblioteca_PedidosDeRetiradaItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliotecas_PedidosDeRetiradasItens_AbpUsers_UserId",
                table: "Bibliotecas_PedidosDeRetiradasItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bibliotecas_PedidosDeRetiradasItens",
                table: "Bibliotecas_PedidosDeRetiradasItens");

            migrationBuilder.RenameTable(
                name: "Bibliotecas_PedidosDeRetiradasItens",
                newName: "Biblioteca_PedidosDeRetiradas");

            migrationBuilder.RenameIndex(
                name: "IX_Bibliotecas_PedidosDeRetiradasItens_UserId",
                table: "Biblioteca_PedidosDeRetiradas",
                newName: "IX_Biblioteca_PedidosDeRetiradas_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Biblioteca_PedidosDeRetiradas",
                table: "Biblioteca_PedidosDeRetiradas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Biblioteca_PedidosDeRetiradaItens_Biblioteca_PedidosDeRetiradas_PedidoDeRetiradaId",
                table: "Biblioteca_PedidosDeRetiradaItens",
                column: "PedidoDeRetiradaId",
                principalTable: "Biblioteca_PedidosDeRetiradas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Biblioteca_PedidosDeRetiradas_AbpUsers_UserId",
                table: "Biblioteca_PedidosDeRetiradas",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Biblioteca_PedidosDeRetiradaItens_Biblioteca_PedidosDeRetiradas_PedidoDeRetiradaId",
                table: "Biblioteca_PedidosDeRetiradaItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Biblioteca_PedidosDeRetiradas_AbpUsers_UserId",
                table: "Biblioteca_PedidosDeRetiradas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Biblioteca_PedidosDeRetiradas",
                table: "Biblioteca_PedidosDeRetiradas");

            migrationBuilder.RenameTable(
                name: "Biblioteca_PedidosDeRetiradas",
                newName: "Bibliotecas_PedidosDeRetiradasItens");

            migrationBuilder.RenameIndex(
                name: "IX_Biblioteca_PedidosDeRetiradas_UserId",
                table: "Bibliotecas_PedidosDeRetiradasItens",
                newName: "IX_Bibliotecas_PedidosDeRetiradasItens_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bibliotecas_PedidosDeRetiradasItens",
                table: "Bibliotecas_PedidosDeRetiradasItens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Biblioteca_PedidosDeRetiradaItens_Bibliotecas_PedidosDeRetiradasItens_PedidoDeRetiradaId",
                table: "Biblioteca_PedidosDeRetiradaItens",
                column: "PedidoDeRetiradaId",
                principalTable: "Bibliotecas_PedidosDeRetiradasItens",
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
    }
}
