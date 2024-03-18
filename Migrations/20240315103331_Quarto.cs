using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNet_ProjetoClix.Migrations
{
    /// <inheritdoc />
    public partial class Quarto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Clientes_ClienteId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Tipos_TipoId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ClienteId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TipoId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Items_ClienteId",
                table: "Items",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TipoId",
                table: "Items",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Clientes_ClienteId",
                table: "Items",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Tipos_TipoId",
                table: "Items",
                column: "TipoId",
                principalTable: "Tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
