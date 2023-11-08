using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AircraftModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AircraftManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AircraftModels_AircraftManufacturers_AircraftManufacturerId",
                        column: x => x.AircraftManufacturerId,
                        principalTable: "AircraftManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TailNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AircraftModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aircrafts_AircraftModels_AircraftModelId",
                        column: x => x.AircraftModelId,
                        principalTable: "AircraftModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AircraftManufacturers_Name",
                table: "AircraftManufacturers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AircraftModels_AircraftManufacturerId",
                table: "AircraftModels",
                column: "AircraftManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_AircraftModels_Name",
                table: "AircraftModels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AircraftModelId",
                table: "Aircrafts",
                column: "AircraftModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "AircraftModels");

            migrationBuilder.DropTable(
                name: "AircraftManufacturers");
        }
    }
}
