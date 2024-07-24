using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyToolsMag.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonNNPlace_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Tools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tools_PersonId",
                table: "Tools",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_PlaceId",
                table: "Tools",
                column: "PlaceId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Person_PersonId",
                table: "Tools");

            migrationBuilder.DropForeignKey(
                name: "FK_Tools_Place_PlaceId",
                table: "Tools");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Tools_PersonId",
                table: "Tools");

            migrationBuilder.DropIndex(
                name: "IX_Tools_PlaceId",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Tools");
        }
    }
}
