using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSmtpUsernameToEmailConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SmtpUsername",
                table: "EmailConfigurations",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 311, DateTimeKind.Utc).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 311, DateTimeKind.Utc).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 311, DateTimeKind.Utc).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 311, DateTimeKind.Utc).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 311, DateTimeKind.Utc).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "EmailConfigurations",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000002"),
                column: "SmtpUsername",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 311, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 311, DateTimeKind.Utc).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 311, DateTimeKind.Utc).AddTicks(9998));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(55));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(70));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(586));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(594));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(701));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(178));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(181));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(185));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(188));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(192));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(205));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(209));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(272));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(275));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(281));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(302));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(305));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(314));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(321));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(331));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(334));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(337));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000034"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(343));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000035"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(346));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000036"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000037"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(353));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000038"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 16, 39, 14, 312, DateTimeKind.Utc).AddTicks(421));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmtpUsername",
                table: "EmailConfigurations");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(4754));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5545));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5528));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5635));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5638));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6330));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6341));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6374));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6547));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5735));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5741));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5764));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000007"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000008"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000009"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000010"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5793));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5804));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000014"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5821));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000015"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5826));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000016"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000017"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000018"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000019"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000020"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5859));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000023"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000024"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000026"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000027"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000029"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000030"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000034"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000035"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000036"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5954));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000037"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5961));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0008-000000000038"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 9, 27, 15, 57, 28, 0, DateTimeKind.Utc).AddTicks(6103));
        }
    }
}
