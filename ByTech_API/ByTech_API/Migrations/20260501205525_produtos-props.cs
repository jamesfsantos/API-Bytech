using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByTech_API.Migrations
{
    /// <inheritdoc />
    public partial class produtosprops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<sbyte>(
                name: "ativo",
                table: "produto",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "data_atualizacao",
                table: "produto",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "data_cadastro",
                table: "produto",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ativo",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "data_atualizacao",
                table: "produto");

            migrationBuilder.DropColumn(
                name: "data_cadastro",
                table: "produto");
        }
    }
}
