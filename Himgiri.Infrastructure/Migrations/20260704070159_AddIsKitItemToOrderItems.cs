using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsKitItemToOrderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsKitItem",
                table: "OrderItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5297));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5652));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5658));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5713));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5733));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5720));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5788));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6154));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6177));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6126));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5897));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5916));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000034"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000035"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5977));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000036"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000037"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000038"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 7, 1, 58, 509, DateTimeKind.Utc).AddTicks(6073));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsKitItem",
                table: "OrderItems");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(8778));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9445));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9471));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9438));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9487));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9575));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9581));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9244));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9254));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9257));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9269));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9272));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9275));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9283));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9286));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9289));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9295));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000034"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000035"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9301));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000036"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000037"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000038"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9312));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 4, 6, 56, 21, 414, DateTimeKind.Utc).AddTicks(9377));
        }
    }
}
