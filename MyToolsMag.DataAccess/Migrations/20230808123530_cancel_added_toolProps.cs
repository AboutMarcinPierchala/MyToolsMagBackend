using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyToolsMag.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class cancel_added_toolProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
