using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace is_kino.Repository.Migrations
{
    public partial class UpdateTicketInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TicketInOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TicketInOrders");
        }
    }
}
