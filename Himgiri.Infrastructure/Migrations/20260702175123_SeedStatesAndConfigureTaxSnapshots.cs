using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedStatesAndConfigureTaxSnapshots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cgst",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Sgst",
                table: "OrderItems");

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "VendorSettings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGst",
                table: "Orders",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "Orders",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "GrandTotal",
                table: "Orders",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeliveryGst",
                table: "Orders",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeliveryFee",
                table: "Orders",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AddColumn<string>(
                name: "CustomerGstStateCode",
                table: "Orders",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerGstin",
                table: "Orders",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerStateId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CustomerStateName",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryCgstAmount",
                table: "Orders",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryIgstAmount",
                table: "Orders",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DeliverySgstAmount",
                table: "Orders",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfSupply",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfSupplyCode",
                table: "Orders",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerAddress",
                table: "Orders",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerCompanyName",
                table: "Orders",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerGstStateCode",
                table: "Orders",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellerGstin",
                table: "Orders",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SellerStateId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SellerStateName",
                table: "Orders",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SupplyType",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "OrderItems",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "LineTotal",
                table: "OrderItems",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "OrderItems",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "HsnCode",
                table: "OrderItems",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "GstPercent",
                table: "OrderItems",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "GstAmount",
                table: "OrderItems",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AddColumn<decimal>(
                name: "BaseAmount",
                table: "OrderItems",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CessAmount",
                table: "OrderItems",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CessPercent",
                table: "OrderItems",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CgstAmount",
                table: "OrderItems",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CgstPercent",
                table: "OrderItems",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IgstAmount",
                table: "OrderItems",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IgstPercent",
                table: "OrderItems",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SgstAmount",
                table: "OrderItems",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SgstPercent",
                table: "OrderItems",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "SupplyType",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StateCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    StateName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GstStateCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    IsUnionTerritory = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9248));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9254));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9259));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9768));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 875, DateTimeKind.Utc).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(890));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(768));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(781));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(847));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(929));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(937));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(1149));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(1153));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(1158));

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "GstStateCode", "IsActive", "IsDeleted", "IsUnionTerritory", "ModifiedBy", "StateCode", "StateName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0008-000000000001"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(286), null, null, null, "01", true, false, true, null, "JK", "Jammu & Kashmir", null },
                    { new Guid("00000000-0000-0000-0008-000000000002"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(294), null, null, null, "02", true, false, false, null, "HP", "Himachal Pradesh", null },
                    { new Guid("00000000-0000-0000-0008-000000000003"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(299), null, null, null, "03", true, false, false, null, "PB", "Punjab", null },
                    { new Guid("00000000-0000-0000-0008-000000000004"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(304), null, null, null, "04", true, false, true, null, "CH", "Chandigarh", null },
                    { new Guid("00000000-0000-0000-0008-000000000005"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(309), null, null, null, "05", true, false, false, null, "UT", "Uttarakhand", null },
                    { new Guid("00000000-0000-0000-0008-000000000006"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(314), null, null, null, "06", true, false, false, null, "HR", "Haryana", null },
                    { new Guid("00000000-0000-0000-0008-000000000007"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(398), null, null, null, "07", true, false, true, null, "DL", "Delhi", null },
                    { new Guid("00000000-0000-0000-0008-000000000008"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(403), null, null, null, "08", true, false, false, null, "RJ", "Rajasthan", null },
                    { new Guid("00000000-0000-0000-0008-000000000009"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(411), null, null, null, "09", true, false, false, null, "UP", "Uttar Pradesh", null },
                    { new Guid("00000000-0000-0000-0008-000000000010"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(417), null, null, null, "10", true, false, false, null, "BR", "Bihar", null },
                    { new Guid("00000000-0000-0000-0008-000000000011"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(442), null, null, null, "11", true, false, false, null, "SK", "Sikkim", null },
                    { new Guid("00000000-0000-0000-0008-000000000012"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(446), null, null, null, "12", true, false, false, null, "AR", "Arunachal Pradesh", null },
                    { new Guid("00000000-0000-0000-0008-000000000013"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(450), null, null, null, "13", true, false, false, null, "NL", "Nagaland", null },
                    { new Guid("00000000-0000-0000-0008-000000000014"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(456), null, null, null, "14", true, false, false, null, "MN", "Manipur", null },
                    { new Guid("00000000-0000-0000-0008-000000000015"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(461), null, null, null, "15", true, false, false, null, "MZ", "Mizoram", null },
                    { new Guid("00000000-0000-0000-0008-000000000016"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(470), null, null, null, "16", true, false, false, null, "TR", "Tripura", null },
                    { new Guid("00000000-0000-0000-0008-000000000017"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(479), null, null, null, "17", true, false, false, null, "ML", "Meghalaya", null },
                    { new Guid("00000000-0000-0000-0008-000000000018"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(483), null, null, null, "18", true, false, false, null, "AS", "Assam", null },
                    { new Guid("00000000-0000-0000-0008-000000000019"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(488), null, null, null, "19", true, false, false, null, "WB", "West Bengal", null },
                    { new Guid("00000000-0000-0000-0008-000000000020"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(492), null, null, null, "20", true, false, false, null, "JH", "Jharkhand", null },
                    { new Guid("00000000-0000-0000-0008-000000000021"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(498), null, null, null, "21", true, false, false, null, "OR", "Odisha", null },
                    { new Guid("00000000-0000-0000-0008-000000000022"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(502), null, null, null, "22", true, false, false, null, "CG", "Chhattisgarh", null },
                    { new Guid("00000000-0000-0000-0008-000000000023"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(507), null, null, null, "23", true, false, false, null, "MP", "Madhya Pradesh", null },
                    { new Guid("00000000-0000-0000-0008-000000000024"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(511), null, null, null, "24", true, false, false, null, "GJ", "Gujarat", null },
                    { new Guid("00000000-0000-0000-0008-000000000026"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(519), null, null, null, "26", true, false, true, null, "DN", "Dadra & Nagar Haveli and Daman & Diu", null },
                    { new Guid("00000000-0000-0000-0008-000000000027"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(524), null, null, null, "27", true, false, false, null, "MH", "Maharashtra", null },
                    { new Guid("00000000-0000-0000-0008-000000000029"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(530), null, null, null, "29", true, false, false, null, "KA", "Karnataka", null },
                    { new Guid("00000000-0000-0000-0008-000000000030"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(534), null, null, null, "30", true, false, false, null, "GA", "Goa", null },
                    { new Guid("00000000-0000-0000-0008-000000000031"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(538), null, null, null, "31", true, false, true, null, "LD", "Lakshadweep", null },
                    { new Guid("00000000-0000-0000-0008-000000000032"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(542), null, null, null, "32", true, false, false, null, "KL", "Kerala", null },
                    { new Guid("00000000-0000-0000-0008-000000000033"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(546), null, null, null, "33", true, false, false, null, "TN", "Tamil Nadu", null },
                    { new Guid("00000000-0000-0000-0008-000000000034"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(550), null, null, null, "34", true, false, true, null, "PY", "Puducherry", null },
                    { new Guid("00000000-0000-0000-0008-000000000035"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(557), null, null, null, "35", true, false, true, null, "AN", "Andaman & Nicobar Islands", null },
                    { new Guid("00000000-0000-0000-0008-000000000036"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(562), null, null, null, "36", true, false, false, null, "TG", "Telangana", null },
                    { new Guid("00000000-0000-0000-0008-000000000037"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(566), null, null, null, "37", true, false, false, null, "AP", "Andhra Pradesh", null },
                    { new Guid("00000000-0000-0000-0008-000000000038"), new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(571), null, null, null, "38", true, false, true, null, "LA", "Ladakh", null }
                });

            migrationBuilder.Sql("UPDATE \"Orders\" SET \"CustomerStateId\" = '00000000-0000-0000-0008-000000000027', \"SellerStateId\" = '00000000-0000-0000-0008-000000000027', \"SellerCompanyName\" = 'Himgiri Goods Pvt. Ltd', \"SellerGstin\" = '27PENDINGCLIENT', \"SellerAddress\" = 'Hinjawadi, Pune, Maharashtra', \"SellerStateName\" = 'Maharashtra', \"SellerGstStateCode\" = '27', \"CustomerStateName\" = 'Maharashtra', \"CustomerGstStateCode\" = '27', \"PlaceOfSupply\" = 'Maharashtra', \"PlaceOfSupplyCode\" = '27', \"SupplyType\" = 1;");
            migrationBuilder.Sql("UPDATE \"OrderItems\" SET \"SupplyType\" = 1;");

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                columns: new[] { "CreatedAt", "Gstin", "StateId" },
                values: new object[] { new DateTime(2026, 7, 2, 17, 51, 18, 876, DateTimeKind.Utc).AddTicks(691), "27PENDINGCLIENT", new Guid("00000000-0000-0000-0008-000000000027") });

            migrationBuilder.CreateIndex(
                name: "IX_VendorSettings_StateId",
                table: "VendorSettings",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerStateId",
                table: "Orders",
                column: "CustomerStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SellerStateId",
                table: "Orders",
                column: "SellerStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_States_CustomerStateId",
                table: "Orders",
                column: "CustomerStateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_States_SellerStateId",
                table: "Orders",
                column: "SellerStateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorSettings_States_StateId",
                table: "VendorSettings",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_States_CustomerStateId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_States_SellerStateId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_VendorSettings_States_StateId",
                table: "VendorSettings");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropIndex(
                name: "IX_VendorSettings_StateId",
                table: "VendorSettings");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerStateId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SellerStateId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "VendorSettings");

            migrationBuilder.DropColumn(
                name: "CustomerGstStateCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerGstin",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerStateId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerStateName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryCgstAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryIgstAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliverySgstAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PlaceOfSupply",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PlaceOfSupplyCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SellerAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SellerCompanyName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SellerGstStateCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SellerGstin",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SellerStateId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SellerStateName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SupplyType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BaseAmount",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CessAmount",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CessPercent",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CgstAmount",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CgstPercent",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IgstAmount",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IgstPercent",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SgstAmount",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SgstPercent",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SupplyType",
                table: "OrderItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGst",
                table: "Orders",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "SubTotal",
                table: "Orders",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "GrandTotal",
                table: "Orders",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeliveryGst",
                table: "Orders",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeliveryFee",
                table: "Orders",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "OrderItems",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "LineTotal",
                table: "OrderItems",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "OrderItems",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "HsnCode",
                table: "OrderItems",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<decimal>(
                name: "GstPercent",
                table: "OrderItems",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "GstAmount",
                table: "OrderItems",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddColumn<decimal>(
                name: "Cgst",
                table: "OrderItems",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Sgst",
                table: "OrderItems",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(712));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(718));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(723));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1502));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000006"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1694));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1696));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2043));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2153));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                columns: new[] { "CreatedAt", "Gstin" },
                values: new object[] { new DateTime(2026, 7, 2, 2, 2, 4, 758, DateTimeKind.Utc).AddTicks(1866), "PENDING_FROM_CLIENT" });
        }
    }
}
