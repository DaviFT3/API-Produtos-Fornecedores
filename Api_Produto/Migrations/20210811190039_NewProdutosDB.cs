using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Produto.Migrations
{
    public partial class NewProdutosDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Fornecedores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Fornecedores");
        }
    }
}
