using Microsoft.EntityFrameworkCore.Migrations;

namespace Website.Component.Content.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "LinkUrl",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Priorty",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "SettingsItemCount",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "SettingsSlugUrl",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Contents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Contents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkUrl",
                table: "Contents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priorty",
                table: "Contents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SettingsItemCount",
                table: "Contents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SettingsSlugUrl",
                table: "Contents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Contents",
                nullable: true);
        }
    }
}