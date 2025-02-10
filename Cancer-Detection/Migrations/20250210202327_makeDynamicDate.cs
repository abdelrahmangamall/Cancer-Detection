using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cancer_Detection.Migrations
{
    /// <inheritdoc />
    public partial class makeDynamicDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CTScans",
                keyColumn: "Id",
                keyValue: new Guid("5fa85f64-5717-4562-b3fc-2c963f66afa8"),
                column: "UploadDate",
                value: new DateTime(2025, 2, 10, 22, 23, 27, 79, DateTimeKind.Local).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "CTScans",
                keyColumn: "Id",
                keyValue: new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa9"),
                column: "UploadDate",
                value: new DateTime(2025, 2, 10, 22, 23, 27, 83, DateTimeKind.Local).AddTicks(7535));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CTScans",
                keyColumn: "Id",
                keyValue: new Guid("5fa85f64-5717-4562-b3fc-2c963f66afa8"),
                column: "UploadDate",
                value: new DateTime(2025, 2, 10, 21, 59, 31, 636, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "CTScans",
                keyColumn: "Id",
                keyValue: new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa9"),
                column: "UploadDate",
                value: new DateTime(2025, 2, 10, 21, 59, 31, 638, DateTimeKind.Local).AddTicks(4374));
        }
    }
}
