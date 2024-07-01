using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TatakelolaKesMas.Migrations
{
    /// <inheritdoc />
    public partial class AddFkRegionInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FkRegionId",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FkRegionId",
                table: "AspNetUsers",
                column: "FkRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Regions_FkRegionId",
                table: "AspNetUsers",
                column: "FkRegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Regions_FkRegionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FkRegionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FkRegionId",
                table: "AspNetUsers");
        }
    }
}
