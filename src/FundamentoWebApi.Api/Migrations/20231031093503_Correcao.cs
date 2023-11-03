using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundamentoWebApi.Api.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtcts",
                table: "Produtcts");

            migrationBuilder.RenameTable(
                name: "Produtcts",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Produtcts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtcts",
                table: "Produtcts",
                column: "Id");
        }
    }
}
