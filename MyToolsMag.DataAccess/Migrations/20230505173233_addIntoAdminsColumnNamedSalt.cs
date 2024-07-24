using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyToolsMag.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addIntoAdminsColumnNamedSalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Admins");
        }
    }
}
