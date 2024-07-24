using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyToolsMag.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createColumns_CatName_PlaceName_PersonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Places_PlaceId",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_Tools_PlaceId",
                table: "Tools");

            migrationBuilder.AlterColumn<int>(
                name: "ToolYear",
                table: "Tools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolCategoryName",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "ToolCategoryName",
                table: "Tools");

            migrationBuilder.AlterColumn<int>(
                name: "ToolYear",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tools_PlaceId",
                table: "Tools",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_Places_PlaceId",
                table: "Tools",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
