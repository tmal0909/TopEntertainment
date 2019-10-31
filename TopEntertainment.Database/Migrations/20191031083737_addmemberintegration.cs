using Microsoft.EntityFrameworkCore.Migrations;

namespace TopEntertainment.Database.Migrations
{
    public partial class addmemberintegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Integration",
                table: "Members",
                type: "decimal(12,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Integration",
                table: "Members");
        }
    }
}
