using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerRazorPage.Migrations
{
    public partial class AddFlowerMediaIdToFlower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowerId",
                table: "FlowerMedia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlowerId",
                table: "FlowerMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
