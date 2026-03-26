using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ByTech_API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false),
                    categoria = table.Column<string>(type: "longtext", nullable: false),
                    descricao = table.Column<string>(type: "longtext", nullable: false),
                    preco_venda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estoque_atual = table.Column<int>(type: "int", nullable: false),
                    marca = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    senha = table.Column<string>(type: "varchar(20)", nullable: false),
                    tipo_usuario = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Campanha_Email",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_admin = table.Column<int>(type: "int", nullable: false),
                    assunto = table.Column<string>(type: "varchar(255)", nullable: false),
                    corpo_mensagem = table.Column<string>(type: "longtext", nullable: false),
                    data_disparo = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanha_Email", x => x.id);
                    table.ForeignKey(
                        name: "FK_Campanha_Email_Usuario_id_admin",
                        column: x => x.id_admin,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mensagem_Contato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    nome_visitante = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    celular = table.Column<string>(type: "varchar(20)", nullable: false),
                    mensagem = table.Column<string>(type: "text", nullable: false),
                    data_envio = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem_Contato", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mensagem_Contato_Usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido_Venda",
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
                    table.PrimaryKey("PK_Pedido_Venda", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_Venda_Usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servico_Manutencao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    protocolo = table.Column<string>(type: "varchar(20)", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_tecnico = table.Column<int>(type: "int", nullable: false),
                    equipamento = table.Column<string>(type: "longtext", nullable: false),
                    descricao_problema = table.Column<string>(type: "longtext", nullable: false),
                    observacoes_tecnicas = table.Column<string>(type: "longtext", nullable: false),
                    status_servico = table.Column<string>(type: "longtext", nullable: false),
                    data_entrada = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico_Manutencao", x => x.id);
                    table.ForeignKey(
                        name: "FK_Servico_Manutencao_Usuario_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servico_Manutencao_Usuario_id_tecnico",
                        column: x => x.id_tecnico,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Item_Venda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_venda = table.Column<int>(type: "int", nullable: false),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "INT(11)", nullable: false),
                    preco_unitario_pago = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_Venda", x => x.id);
                    table.ForeignKey(
                        name: "FK_Item_Venda_Pedido_Venda_id_venda",
                        column: x => x.id_venda,
                        principalTable: "Pedido_Venda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Venda_Produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_venda = table.Column<int>(type: "int", nullable: false),
                    metodo = table.Column<string>(type: "longtext", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    data_confirmacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Pedido_Venda_id_venda",
                        column: x => x.id_venda,
                        principalTable: "Pedido_Venda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Campanha_Email_id_admin",
                table: "Campanha_Email",
                column: "id_admin");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Venda_id_produto",
                table: "Item_Venda",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Venda_id_venda",
                table: "Item_Venda",
                column: "id_venda");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_Contato_id_usuario",
                table: "Mensagem_Contato",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_id_venda",
                table: "Pagamento",
                column: "id_venda",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Venda_id_usuario",
                table: "Pedido_Venda",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_Manutencao_id_cliente",
                table: "Servico_Manutencao",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_Manutencao_id_tecnico",
                table: "Servico_Manutencao",
                column: "id_tecnico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campanha_Email");

            migrationBuilder.DropTable(
                name: "Item_Venda");

            migrationBuilder.DropTable(
                name: "Mensagem_Contato");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Servico_Manutencao");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Pedido_Venda");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
