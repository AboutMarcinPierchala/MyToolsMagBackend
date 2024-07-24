using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyToolsMag.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddToolCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToolCategoryId",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ToolCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ToolCategoryId",
                table: "Tools",
                column: "ToolCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_ToolCategory_ToolCategoryId",
                table: "Tools",
                column: "ToolCategoryId",
                principalTable: "ToolCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_ToolCategory_ToolCategoryId",
                table: "Tools");

            migrationBuilder.DropTable(
                name: "ToolCategory");

            migrationBuilder.DropIndex(
                name: "IX_Tools_ToolCategoryId",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "ToolCategoryId",
                table: "Tools");
        }
    }
}
