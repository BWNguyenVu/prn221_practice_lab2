using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerRazorPage.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_FlowerMedia_FlowerMediaId",
                table: "Flowers");

            migrationBuilder.DropIndex(
                name: "IX_Flowers_FlowerMediaId",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "FlowerMediaId",
                table: "Flowers");

            migrationBuilder.AlterColumn<string>(
                name: "FlowerId",
                table: "FlowerMedia",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerMedia_FlowerId",
                table: "FlowerMedia",
                column: "FlowerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerMedia_Flowers_FlowerId",
                table: "FlowerMedia",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerMedia_Flowers_FlowerId",
                table: "FlowerMedia");

            migrationBuilder.DropIndex(
                name: "IX_FlowerMedia_FlowerId",
                table: "FlowerMedia");

            migrationBuilder.AddColumn<string>(
                name: "FlowerMediaId",
                table: "Flowers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FlowerId",
                table: "FlowerMedia",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_FlowerMediaId",
                table: "Flowers",
                column: "FlowerMediaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flowers_FlowerMedia_FlowerMediaId",
                table: "Flowers",
                column: "FlowerMediaId",
                principalTable: "FlowerMedia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
