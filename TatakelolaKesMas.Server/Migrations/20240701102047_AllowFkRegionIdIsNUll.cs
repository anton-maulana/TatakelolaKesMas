using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TatakelolaKesMas.Migrations
{
    /// <inheritdoc />
    public partial class AllowFkRegionIdIsNUll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Regions_fkParentId",
                table: "Regions");

            migrationBuilder.AlterColumn<string>(
                name: "fkParentId",
                table: "Regions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Regions_fkParentId",
                table: "Regions",
                column: "fkParentId",
                principalTable: "Regions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Regions_fkParentId",
                table: "Regions");

            migrationBuilder.AlterColumn<string>(
                name: "fkParentId",
                table: "Regions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Regions_fkParentId",
                table: "Regions",
                column: "fkParentId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
