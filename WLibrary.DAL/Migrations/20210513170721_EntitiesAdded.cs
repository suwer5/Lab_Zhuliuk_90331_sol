using Microsoft.EntityFrameworkCore.Migrations;

namespace WLibrary.DAL.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantsGroups",
                columns: table => new
                {
                    PlantsGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantsGroups", x => x.PlantsGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Plantses",
                columns: table => new
                {
                    PlantsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantsGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantses", x => x.PlantsId);
                    table.ForeignKey(
                        name: "FK_Plantses_PlantsGroups_PlantsGroupId",
                        column: x => x.PlantsGroupId,
                        principalTable: "PlantsGroups",
                        principalColumn: "PlantsGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plantses_PlantsGroupId",
                table: "Plantses",
                column: "PlantsGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plantses");

            migrationBuilder.DropTable(
                name: "PlantsGroups");
        }
    }
}
