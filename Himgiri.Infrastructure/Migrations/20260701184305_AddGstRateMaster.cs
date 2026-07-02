using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGstRateMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GstRateId",
                table: "Items",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DefaultGstRateId",
                table: "ItemCategories",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GstRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HsnCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Rate = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    Cgst = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    Sgst = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    Igst = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    Cess = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    table.PrimaryKey("PK_GstRates", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(1732));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(1740));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(1743));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                columns: new[] { "CreatedAt", "DefaultGstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2123), null });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                columns: new[] { "CreatedAt", "DefaultGstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2128), null });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                columns: new[] { "CreatedAt", "DefaultGstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2130), null });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                columns: new[] { "CreatedAt", "DefaultGstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2131), null });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                columns: new[] { "CreatedAt", "DefaultGstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2133), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2254), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2260), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2269), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2274), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2279), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2233), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2240), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2246), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2334), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2341), null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2349), null });

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2446));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2455));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 43, 2, 334, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.CreateIndex(
                name: "IX_Items_GstRateId",
                table: "Items",
                column: "GstRateId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_DefaultGstRateId",
                table: "ItemCategories",
                column: "DefaultGstRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCategories_GstRates_DefaultGstRateId",
                table: "ItemCategories",
                column: "DefaultGstRateId",
                principalTable: "GstRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_GstRates_GstRateId",
                table: "Items",
                column: "GstRateId",
                principalTable: "GstRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCategories_GstRates_DefaultGstRateId",
                table: "ItemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_GstRates_GstRateId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "GstRates");

            migrationBuilder.DropIndex(
                name: "IX_Items_GstRateId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_ItemCategories_DefaultGstRateId",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "GstRateId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "DefaultGstRateId",
                table: "ItemCategories");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(14));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(18));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(411));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(628));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(642));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(647));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(653));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(663));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 17, 11, 37, 8, 411, DateTimeKind.Utc).AddTicks(498));
        }
    }
}
