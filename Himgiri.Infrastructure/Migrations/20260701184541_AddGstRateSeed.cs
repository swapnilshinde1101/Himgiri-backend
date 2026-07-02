using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGstRateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(3454));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(3459));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4365));

            migrationBuilder.InsertData(
                table: "GstRates",
                columns: new[] { "Id", "Cess", "Cgst", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "EffectiveFrom", "EffectiveTo", "HsnCode", "Igst", "IsActive", "IsDeleted", "ModifiedBy", "Name", "Rate", "Sgst", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0009-000000000001"), 0m, 0m, new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4467), null, null, null, "School Textbooks Exempt from GST", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "4901", 0m, true, false, null, "Books Exempt", 0m, 0m, null },
                    { new Guid("00000000-0000-0000-0009-000000000002"), 0m, 6m, new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4487), null, null, null, "Notebooks and Stationery items under 12% GST", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "4820", 12m, true, false, null, "Stationery GST 12%", 12m, 6m, null },
                    { new Guid("00000000-0000-0000-0009-000000000003"), 0m, 9m, new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4495), null, null, null, "School Bags and Backpacks under 18% GST", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "4202", 18m, true, false, null, "Bags GST 18%", 18m, 9m, null },
                    { new Guid("00000000-0000-0000-0009-000000000004"), 0m, 9m, new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4501), null, null, null, "Logistics and Shipping charges under 18% GST", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "9965", 18m, true, false, null, "Delivery Fee GST 18%", 18m, 9m, null }
                });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                columns: new[] { "CreatedAt", "DefaultGstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4627), new Guid("00000000-0000-0000-0009-000000000001") });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                columns: new[] { "CreatedAt", "DefaultGstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4636), new Guid("00000000-0000-0000-0009-000000000002") });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                columns: new[] { "CreatedAt", "DefaultGstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4639), new Guid("00000000-0000-0000-0009-000000000002") });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                columns: new[] { "CreatedAt", "DefaultGstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4642), new Guid("00000000-0000-0000-0009-000000000003") });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                columns: new[] { "CreatedAt", "DefaultGstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4645), new Guid("00000000-0000-0000-0009-000000000004") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4854), new Guid("00000000-0000-0000-0009-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4871), new Guid("00000000-0000-0000-0009-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4883), new Guid("00000000-0000-0000-0009-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4892), new Guid("00000000-0000-0000-0009-000000000001") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4903), new Guid("00000000-0000-0000-0009-000000000001") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4819), new Guid("00000000-0000-0000-0009-000000000001") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4831), new Guid("00000000-0000-0000-0009-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4842), new Guid("00000000-0000-0000-0009-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4913), new Guid("00000000-0000-0000-0009-000000000001") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4924), new Guid("00000000-0000-0000-0009-000000000001") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                columns: new[] { "CreatedAt", "GstRateId" },
                values: new object[] { new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4933), new Guid("00000000-0000-0000-0009-000000000003") });

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4746));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"));

            migrationBuilder.DeleteData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"));

            migrationBuilder.DeleteData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"));

            migrationBuilder.DeleteData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"));

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
        }
    }
}
