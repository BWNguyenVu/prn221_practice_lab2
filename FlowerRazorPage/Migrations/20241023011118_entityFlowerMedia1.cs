using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerRazorPage.Migrations
{
    public partial class entityFlowerMedia1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlowerMediaId",
                table: "Flowers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FlowerMedia",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerMedia", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_FlowerMedia_FlowerMediaId",
                table: "Flowers");

            migrationBuilder.DropTable(
                name: "FlowerMedia");

            migrationBuilder.DropIndex(
                name: "IX_Flowers_FlowerMediaId",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "FlowerMediaId",
                table: "Flowers");
        }
    }
}
