using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByTech_API.Migrations
{
    /// <inheritdoc />
    public partial class pedidoprops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cidade",
                table: "pedido",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "pedido",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "complemento",
                table: "pedido",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "pedido",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cidade",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "cep",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "complemento",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "endereco",
                table: "pedido");
        }
    }
}
