using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPerformanceIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(1938));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2934));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2948));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2876));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2893));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(3304));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(3311));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(3323));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2379));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2386));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2439));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2554));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2583));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000034"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2604));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000035"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000036"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2618));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000037"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2631));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000038"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 24, 17, 30, 38, 206, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.CreateIndex(
                name: "IX_StockLogs_CreatedAt",
                table: "StockLogs",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Mobile",
                table: "Orders",
                column: "Mobile");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Mobile_Pincode",
                table: "Orders",
                columns: new[] { "Mobile", "Pincode" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockLogs_CreatedAt",
                table: "StockLogs");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Mobile",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Mobile_Pincode",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3541));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3546));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3550));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3985));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3989));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3976));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(3994));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4414));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4435));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4572));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4133));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4144));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4158));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4192));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4205));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000034"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000035"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000036"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000037"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000038"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 11, 36, 36, 508, DateTimeKind.Utc).AddTicks(4325));
        }
    }
}
