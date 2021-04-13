using Microsoft.EntityFrameworkCore.Migrations;

namespace PedidoAPI.Migrations
{
    public partial class statusmesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ocupada",
                table: "Mesa",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ocupada",
                table: "Mesa");
        }
    }
}
