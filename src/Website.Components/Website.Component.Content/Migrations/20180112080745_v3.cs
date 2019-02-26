using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Component.Content.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LayoutSize",
                table: "Contents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LayoutSize",
                table: "Contents",
                nullable: true);
        }
    }
}