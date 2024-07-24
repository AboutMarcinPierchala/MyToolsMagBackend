using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyToolsMag.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class adminNick_change_to_Username : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminNick",
                table: "Admins",
                newName: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Admins",
                newName: "AdminNick");
        }
    }
}
