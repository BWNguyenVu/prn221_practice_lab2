using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerRazorPage.Migrations
{
    public partial class entityRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FlowerMedia_FlowerId",
                table: "FlowerMedia");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerMedia_FlowerId",
                table: "FlowerMedia",
                column: "FlowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FlowerMedia_FlowerId",
                table: "FlowerMedia");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerMedia_FlowerId",
                table: "FlowerMedia",
                column: "FlowerId",
                unique: true);
        }
    }
}
