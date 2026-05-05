using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ByTech_API.Migrations
{
    /// <inheritdoc />
    public partial class addtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    data_pedido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    valor_total_pedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NomeUsuario = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    celular = table.Column<string>(type: "varchar(20)", nullable: false),
                    cpf = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "item_pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "INT(11)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nome_produto = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_pedido_pedido_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_pedido_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_item_pedido_id_pedido",
                table: "item_pedido",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_item_pedido_id_produto",
                table: "item_pedido",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_id_usuario",
                table: "pedido",
                column: "id_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_pagamento_pedido_id_pedido",
                table: "pagamento",
                column: "id_pedido",
                principalTable: "pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pagamento_pedido_id_pedido",
                table: "pagamento");

            migrationBuilder.DropTable(
                name: "item_pedido");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.RenameColumn(
                name: "id_pedido",
                table: "pagamento",
                newName: "id_venda");

            migrationBuilder.RenameIndex(
                name: "IX_pagamento_id_pedido",
                table: "pagamento",
                newName: "IX_pagamento_id_venda");

            migrationBuilder.CreateTable(
                name: "pedido_venda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    data_pedido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    valor_total_pedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido_venda", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_venda_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "item_venda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    id_venda = table.Column<int>(type: "int", nullable: false),
                    preco_unitario_pago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantidade = table.Column<int>(type: "INT(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_venda", x => x.id);
                    table.ForeignKey(
                        name: "FK_item_venda_pedido_venda_id_venda",
                        column: x => x.id_venda,
                        principalTable: "pedido_venda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_item_venda_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_item_venda_id_produto",
                table: "item_venda",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_item_venda_id_venda",
                table: "item_venda",
                column: "id_venda");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_venda_id_usuario",
                table: "pedido_venda",
                column: "id_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_pagamento_pedido_venda_id_venda",
                table: "pagamento",
                column: "id_venda",
                principalTable: "pedido_venda",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
