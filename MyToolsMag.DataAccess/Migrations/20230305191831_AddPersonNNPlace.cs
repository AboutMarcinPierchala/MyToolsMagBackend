using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyToolsMag.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonNNPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Tools",
                newName: "ToolYear");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tools",
                newName: "ToolName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToolYear",
                table: "Tools",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "ToolName",
                table: "Tools",
                newName: "Name");
        }
    }
}
