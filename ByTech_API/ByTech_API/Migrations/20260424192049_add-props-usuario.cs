using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByTech_API.Migrations
{
    /// <inheritdoc />
    public partial class addpropsusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "usuario",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cidade",
                table: "usuario",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "complemento",
                table: "usuario",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "usuario",
                type: "varchar(9)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "usuario",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cep",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "cidade",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "complemento",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "endereco",
                table: "usuario");
        }
    }
}
