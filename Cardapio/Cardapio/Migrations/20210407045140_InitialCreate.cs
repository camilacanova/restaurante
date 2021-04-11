using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CardapioService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cardapio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCategoria = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCardapio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeItem = table.Column<string>(type: "text", nullable: true),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    CardapioId = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCardapio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCardapio_Cardapio_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adicional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    ItemCardapioId = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adicional_ItemCardapio_ItemCardapioId",
                        column: x => x.ItemCardapioId,
                        principalTable: "ItemCardapio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoAdicional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeItem = table.Column<string>(type: "text", nullable: true),
                    AdicionalId = table.Column<int>(type: "integer", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAdicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoAdicional_Adicional_AdicionalId",
                        column: x => x.AdicionalId,
                        principalTable: "Adicional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cardapio",
                columns: new[] { "Id", "Ativo", "Nome", "Observacao" },
                values: new object[] { 1, true, "Café da manhã", "Teste" });

            migrationBuilder.InsertData(
                table: "Restaurante",
                columns: new[] { "Id", "Ativo", "Nome", "Observacao" },
                values: new object[] { 1, true, "Restaurante A", "Teste" });

            migrationBuilder.InsertData(
                table: "ItemCardapio",
                columns: new[] { "Id", "Ativo", "CardapioId", "NomeItem", "Observacao", "Valor" },
                values: new object[,]
                {
                    { 1, true, 1, "Ovos Mexidos", "Teste", 10m },
                    { 2, true, 1, "Café", "Teste", 10m },
                    { 3, true, 1, "Bolo de milho", "Teste", 10m },
                    { 4, true, 1, "Baguete", "Teste", 10m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adicional_ItemCardapioId",
                table: "Adicional",
                column: "ItemCardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCardapio_CardapioId",
                table: "ItemCardapio",
                column: "CardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoAdicional_AdicionalId",
                table: "TipoAdicional",
                column: "AdicionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "TipoAdicional");

            migrationBuilder.DropTable(
                name: "Adicional");

            migrationBuilder.DropTable(
                name: "ItemCardapio");

            migrationBuilder.DropTable(
                name: "Cardapio");
        }
    }
}
