using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDefaultAdminPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8005), "$2a$11$j09n7x7i8xRS6NBjXvKVyu//iG1fL.tUuWH9WGZ4mX6RIBnw.ziqa" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8011), "$2a$11$j09n7x7i8xRS6NBjXvKVyu//iG1fL.tUuWH9WGZ4mX6RIBnw.ziqa" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8015), "$2a$11$j09n7x7i8xRS6NBjXvKVyu//iG1fL.tUuWH9WGZ4mX6RIBnw.ziqa" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8018), "$2a$11$j09n7x7i8xRS6NBjXvKVyu//iG1fL.tUuWH9WGZ4mX6RIBnw.ziqa" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8021), "$2a$11$j09n7x7i8xRS6NBjXvKVyu//iG1fL.tUuWH9WGZ4mX6RIBnw.ziqa" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8220));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8684));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8419));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8439));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8475));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8481));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8489));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000034"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000035"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000036"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8507));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000037"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8510));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000038"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 18, 32, 7, 953, DateTimeKind.Utc).AddTicks(8573));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(4902), "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(4908), "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(4914), "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(4919), "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe" });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(4937), "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5340));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5345));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5394));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5805));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5818));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5824));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5847));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(6021));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(6027));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5452));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5457));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5470));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5485));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5489));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5511));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5514));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5519));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5523));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5553));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5566));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5574));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5585));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5597));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5601));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5615));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000034"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5619));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000035"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000036"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000037"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5641));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000038"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5644));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 26, 17, 56, 22, 632, DateTimeKind.Utc).AddTicks(5722));
        }
    }
}
