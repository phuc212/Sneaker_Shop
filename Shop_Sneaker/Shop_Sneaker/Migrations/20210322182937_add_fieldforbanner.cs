using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop_Sneaker.Migrations
{
    public partial class add_fieldforbanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "banners",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "banners");
        }
    }
}
