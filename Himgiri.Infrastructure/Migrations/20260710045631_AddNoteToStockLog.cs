using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNoteToStockLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "StockLogs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(7805));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(7813));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8289));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8738));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8802));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8439));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8454));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8481));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8493));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8496));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8510));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8525));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000034"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000035"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8573));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000036"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000037"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000038"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8584));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 10, 4, 56, 28, 643, DateTimeKind.Utc).AddTicks(8681));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "StockLogs");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(585));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2358));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2453));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2734));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1903));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1976));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000034"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000035"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2022));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000036"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000037"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000038"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 8, 11, 32, 22, 455, DateTimeKind.Utc).AddTicks(2194));
        }
    }
}
