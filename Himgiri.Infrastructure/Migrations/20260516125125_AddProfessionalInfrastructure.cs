using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProfessionalInfrastructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "VendorSettings",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "VendorSettings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "VendorSettings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "VendorSettings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "VendorSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VendorSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "VendorSettings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Suppliers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Suppliers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Suppliers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Suppliers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Suppliers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "StockLogs",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "StockLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "StockLogs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "StockLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "StockLogs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StockLogs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "StockLogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PurchaseOrders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "PurchaseOrders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PurchaseOrders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "PurchaseOrders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PurchaseOrders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PurchaseOrders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "PurchaseOrders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PurchaseOrderItems",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "PurchaseOrderItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "PurchaseOrderItems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "PurchaseOrderItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PurchaseOrderItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PurchaseOrderItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "PurchaseOrderItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderItems",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "OrderItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "OrderItems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "OrderItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OrderItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "OrderItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Items",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Items",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Items",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "Items",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Items",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "Items",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "GstSettings",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "GstSettings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "GstSettings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "GstSettings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GstSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "GstSettings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AdminUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AdminUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "AdminUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AdminUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                table: "AdminUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdminUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LockoutEnd",
                table: "AdminUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedBy",
                table: "AdminUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApiErrorLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestType = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Payload = table.Column<string>(type: "text", nullable: true),
                    QueryParams = table.Column<string>(type: "text", nullable: true),
                    Response = table.Column<string>(type: "text", nullable: true),
                    ResponseCode = table.Column<int>(type: "integer", nullable: false),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    UserAgent = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserEmail = table.Column<string>(type: "text", nullable: true),
                    ExceptionMessage = table.Column<string>(type: "text", nullable: true),
                    StackTrace = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_ApiErrorLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                columns: new[] { "AccessFailedCount", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "LockoutEnd", "ModifiedBy", "UpdatedAt" },
                values: new object[] { 0, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3357), null, null, null, false, null, null, null });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                columns: new[] { "AccessFailedCount", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "LockoutEnd", "ModifiedBy", "UpdatedAt" },
                values: new object[] { 0, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3361), null, null, null, false, null, null, null });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                columns: new[] { "AccessFailedCount", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "LockoutEnd", "ModifiedBy", "UpdatedAt" },
                values: new object[] { 0, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3364), null, null, null, false, null, null, null });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                columns: new[] { "AccessFailedCount", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "LockoutEnd", "ModifiedBy", "UpdatedAt" },
                values: new object[] { 0, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3367), null, null, null, false, null, null, null });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                columns: new[] { "AccessFailedCount", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "LockoutEnd", "ModifiedBy", "UpdatedAt" },
                values: new object[] { 0, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3370), null, null, null, false, null, null, null });

            migrationBuilder.UpdateData(
                table: "GstSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000001"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EffectiveFrom", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3559), null, null, null, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3549), false, null, null });

            migrationBuilder.UpdateData(
                table: "GstSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000002"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EffectiveFrom", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3565), null, null, null, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3560), false, null, null });

            migrationBuilder.UpdateData(
                table: "GstSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000003"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EffectiveFrom", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3569), null, null, null, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3566), false, null, null });

            migrationBuilder.UpdateData(
                table: "GstSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000004"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EffectiveFrom", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3576), null, null, null, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3570), false, null, null });

            migrationBuilder.UpdateData(
                table: "GstSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000005"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EffectiveFrom", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3579), null, null, null, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3577), false, null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3643), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3648), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3652), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3656), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3660), null, null, null, false, null, null });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                columns: new[] { "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "IsDeleted", "ModifiedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3612), null, null, null, true, false, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiErrorLogs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VendorSettings");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "VendorSettings");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "VendorSettings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "VendorSettings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VendorSettings");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "VendorSettings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StockLogs");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "StockLogs");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "StockLogs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "StockLogs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StockLogs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StockLogs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "GstSettings");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "GstSettings");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "GstSettings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GstSettings");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "GstSettings");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AdminUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "VendorSettings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Suppliers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "StockLogs",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PurchaseOrders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PurchaseOrderItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Items",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "GstSettings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AdminUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6471), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6472) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6476), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6477) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6480), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6481) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6484), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6485) });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6488), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6488) });

            migrationBuilder.UpdateData(
                table: "GstSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000001"),
                columns: new[] { "CreatedAt", "EffectiveFrom", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6764), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6738), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6765) });

            migrationBuilder.UpdateData(
                table: "GstSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000002"),
                columns: new[] { "CreatedAt", "EffectiveFrom", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6772), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6766), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6773) });

            migrationBuilder.UpdateData(
                table: "GstSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000003"),
                columns: new[] { "CreatedAt", "EffectiveFrom", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6777), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6773), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "GstSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000004"),
                columns: new[] { "CreatedAt", "EffectiveFrom", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6781), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6778), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6782) });

            migrationBuilder.UpdateData(
                table: "GstSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0002-000000000005"),
                columns: new[] { "CreatedAt", "EffectiveFrom", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6785), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6782), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6786) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6864), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6864) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6869), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6877), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6877) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6881), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6882) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6886), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6886) });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6820), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6821) });
        }
    }
}
