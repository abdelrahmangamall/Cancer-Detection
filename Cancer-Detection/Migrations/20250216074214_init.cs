using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cancer_Detection.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "CTScans",
                newName: "FilePath");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "CTScans",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "CTScans",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "CTScans",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "CTScans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoredFileName",
                table: "CTScans",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "CTScans",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CTScans",
                keyColumn: "Id",
                keyValue: new Guid("5fa85f64-5717-4562-b3fc-2c963f66afa8"),
                columns: new[] { "ContentType", "FileName", "FileSize", "Height", "StoredFileName", "UploadDate", "Width" },
                values: new object[] { "image/png", "undraw_Dev_productivity_re_fylf.png", 1024L, 600, "unique_filename_1.png", new DateTime(2025, 2, 16, 9, 42, 13, 613, DateTimeKind.Local).AddTicks(4028), 800 });

            migrationBuilder.UpdateData(
                table: "CTScans",
                keyColumn: "Id",
                keyValue: new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa9"),
                columns: new[] { "ContentType", "FileName", "FileSize", "Height", "StoredFileName", "UploadDate", "Width" },
                values: new object[] { "image/png", "download.png", 2048L, 768, "unique_filename_2.png", new DateTime(2025, 2, 16, 9, 42, 13, 635, DateTimeKind.Local).AddTicks(6902), 1024 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "CTScans");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "CTScans");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "CTScans");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "CTScans");

            migrationBuilder.DropColumn(
                name: "StoredFileName",
                table: "CTScans");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "CTScans");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "CTScans",
                newName: "ImagePath");

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
    }
}
