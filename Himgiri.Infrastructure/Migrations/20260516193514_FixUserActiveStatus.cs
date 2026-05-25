using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserActiveStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6811));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 35, 11, 696, DateTimeKind.Utc).AddTicks(6881));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1859));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 19, 1, 47, 230, DateTimeKind.Utc).AddTicks(1928));
        }
    }
}
