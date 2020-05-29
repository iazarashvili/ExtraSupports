using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtraSupports.Migrations
{
    public partial class firt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Ticket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ticket");
        }
    }
}
