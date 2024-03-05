using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class hospital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HospitalBranchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranchFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalBranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalBranchFeatures_HospitalBranchs_HospitalBranchId",
                        column: x => x.HospitalBranchId,
                        principalTable: "HospitalBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranchLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalBranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalBranchLanguages_HospitalBranchs_HospitalBranchId",
                        column: x => x.HospitalBranchId,
                        principalTable: "HospitalBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranchPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalBranchId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalBranchPhotos_HospitalBranchs_HospitalBranchId",
                        column: x => x.HospitalBranchId,
                        principalTable: "HospitalBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HospitalBranchFeatureLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalBranchFeatureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalBranchFeatureLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalBranchFeatureLanguages_HospitalBranchFeatures_HospitalBranchFeatureId",
                        column: x => x.HospitalBranchFeatureId,
                        principalTable: "HospitalBranchFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBranchFeatureLanguages_HospitalBranchFeatureId",
                table: "HospitalBranchFeatureLanguages",
                column: "HospitalBranchFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBranchFeatures_HospitalBranchId",
                table: "HospitalBranchFeatures",
                column: "HospitalBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBranchLanguages_HospitalBranchId",
                table: "HospitalBranchLanguages",
                column: "HospitalBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalBranchPhotos_HospitalBranchId",
                table: "HospitalBranchPhotos",
                column: "HospitalBranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalBranchFeatureLanguages");

            migrationBuilder.DropTable(
                name: "HospitalBranchLanguages");

            migrationBuilder.DropTable(
                name: "HospitalBranchPhotos");

            migrationBuilder.DropTable(
                name: "HospitalBranchFeatures");

            migrationBuilder.DropTable(
                name: "HospitalBranchs");
        }
    }
}
