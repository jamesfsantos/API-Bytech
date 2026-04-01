using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByTech_API.Migrations
{
    /// <inheritdoc />
    public partial class colunaimagemproduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Produto",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Produto");
        }
    }
}
