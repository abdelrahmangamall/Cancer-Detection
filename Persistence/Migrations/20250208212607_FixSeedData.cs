using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CTScans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTScans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTScans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PredictionResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prediction = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Confidence = table.Column<float>(type: "real", nullable: false),
                    PredictionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictionResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredictionResults_CTScans_ScanId",
                        column: x => x.ScanId,
                        principalTable: "CTScans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "admin@example.com", new byte[] { 1, 2, 3 }, new byte[] { 4, 5, 6 } },
                    { new Guid("4fa85f64-5717-4562-b3fc-2c963f66afa7"), "user@example.com", new byte[] { 7, 8, 9 }, new byte[] { 10, 11, 12 } }
                });

            migrationBuilder.InsertData(
                table: "CTScans",
                columns: new[] { "Id", "ImagePath", "UploadDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("5fa85f64-5717-4562-b3fc-2c963f66afa8"), "/images/scan1.jpg", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6") },
                    { new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa9"), "/images/scan2.jpg", new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4fa85f64-5717-4562-b3fc-2c963f66afa7") }
                });

            migrationBuilder.InsertData(
                table: "PredictionResults",
                columns: new[] { "Id", "Confidence", "Prediction", "PredictionDate", "ScanId" },
                values: new object[,]
                {
                    { new Guid("7fa85f64-5717-4562-b3fc-2c963f66afa0"), 0.95f, "NSCLC", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5fa85f64-5717-4562-b3fc-2c963f66afa8") },
                    { new Guid("7fa85f64-5717-4562-b3fc-2c963f66afc9"), 0.89f, "SCLC", new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CTScans_UserId",
                table: "CTScans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PredictionResults_ScanId",
                table: "PredictionResults",
                column: "ScanId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredictionResults");

            migrationBuilder.DropTable(
                name: "CTScans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
