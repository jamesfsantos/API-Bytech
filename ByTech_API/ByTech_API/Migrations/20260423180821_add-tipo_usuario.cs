using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ByTech_API.Migrations
{
    /// <inheritdoc />
    public partial class addtipo_usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameColumn(
                name: "SenhaSalt",
                table: "usuario",
                newName: "senhaSalt");

            migrationBuilder.AlterColumn<string>(
                name: "senhaSalt",
                table: "usuario",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            

           

            

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_tipo_usuario_id_tipo_usuario",
                table: "usuario",
                column: "id_tipo_usuario",
                principalTable: "tipo_usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_tipo_usuario_id_tipo_usuario",
                table: "usuario");

            migrationBuilder.DropTable(
                name: "tipo_usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_id_tipo_usuario",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "id_tipo_usuario",
                table: "usuario");

            migrationBuilder.RenameColumn(
                name: "senhaSalt",
                table: "usuario",
                newName: "SenhaSalt");

            migrationBuilder.AlterColumn<string>(
                name: "SenhaSalt",
                table: "usuario",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddColumn<string>(
                name: "tipo_usuario",
                table: "usuario",
                type: "longtext",
                nullable: false);
        }
    }
}
