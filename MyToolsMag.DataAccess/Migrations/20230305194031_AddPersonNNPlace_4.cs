using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyToolsMag.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonNNPlace_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Person_PersonId",
                table: "Tools");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Place_PlaceId",
                table: "Tools");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_ToolCategory_ToolCategoryId",
                table: "Tools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToolCategory",
                table: "ToolCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Place",
                table: "Place");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "ToolCategory",
                newName: "ToolCategories");

            migrationBuilder.RenameTable(
                name: "Place",
                newName: "Places");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToolCategories",
                table: "ToolCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_Persons_PersonId",
                table: "Tools",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_Places_PlaceId",
                table: "Tools",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_ToolCategories_ToolCategoryId",
                table: "Tools",
                column: "ToolCategoryId",
                principalTable: "ToolCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Persons_PersonId",
                table: "Tools");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Places_PlaceId",
                table: "Tools");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_ToolCategories_ToolCategoryId",
                table: "Tools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToolCategories",
                table: "ToolCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "ToolCategories",
                newName: "ToolCategory");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Place");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToolCategory",
                table: "ToolCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Place",
                table: "Place",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_Person_PersonId",
                table: "Tools",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_Place_PlaceId",
                table: "Tools",
                column: "PlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tools_ToolCategory_ToolCategoryId",
                table: "Tools",
                column: "ToolCategoryId",
                principalTable: "ToolCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
