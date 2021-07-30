using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaGuideToGreatness.DAL.Migrations
{
    public partial class removegain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_GainPerLevel_GainId",
                table: "Heroes");

            migrationBuilder.DropTable(
                name: "GainPerLevel");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_GainId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "GainId",
                table: "Heroes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GainId",
                table: "Heroes",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GainPerLevel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GainPerLevel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_GainId",
                table: "Heroes",
                column: "GainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_GainPerLevel_GainId",
                table: "Heroes",
                column: "GainId",
                principalTable: "GainPerLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
