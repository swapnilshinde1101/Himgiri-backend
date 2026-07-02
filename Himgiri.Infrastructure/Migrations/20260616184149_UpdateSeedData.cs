using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CreatedAt", "StockQty", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4138), 120, 150 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CreatedAt", "StockQty", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4146), 250, 300 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CreatedAt", "StockQty", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4153), 180, 200 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CreatedAt", "StockQty", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4166), 90, 100 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CreatedAt", "StorageStatus", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4172), 1, 150 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "CompletedAt", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "ImageUrl", "IsActive", "IsDeleted", "IsStockInitialized", "ModifiedBy", "Mrp", "Name", "Price", "PurchasePrice", "StockQty", "StorageStatus", "TargetQty", "Unit", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0004-000000000011"), new Guid("00000000-0000-0000-0006-000000000001"), null, new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4039), null, null, null, "Interactive English Reader for Grade 1", "https://picsum.photos/200/300?random=11", true, false, true, null, 180m, "Grade 1 English Textbook", 180m, 120m, 150, 0, 150, "Pieces (Pcs)", null },
                    { new Guid("00000000-0000-0000-0004-000000000012"), new Guid("00000000-0000-0000-0006-000000000003"), null, new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4048), null, null, null, "Ruled Journal for Grade 1 practice", "https://picsum.photos/200/300?random=12", true, false, true, null, 45m, "Grade 1 Red Notebook", 40m, 25m, 300, 0, 300, "Pieces (Pcs)", null },
                    { new Guid("00000000-0000-0000-0004-000000000013"), new Guid("00000000-0000-0000-0006-000000000002"), null, new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4055), null, null, null, "Stationery box containing pencils, eraser, and ruler", "https://picsum.photos/200/300?random=13", true, false, true, null, 80m, "Grade 1 Premium Pencil Box", 70m, 45m, 200, 0, 200, "Pieces (Pcs)", null },
                    { new Guid("00000000-0000-0000-0004-000000000031"), new Guid("00000000-0000-0000-0006-000000000001"), null, new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4186), null, null, null, "Mathematics textbook for Grade 3", "https://picsum.photos/200/300?random=31", true, false, true, null, 220m, "Grade 3 Math Magic", 220m, 150m, 140, 0, 150, "Pieces (Pcs)", null },
                    { new Guid("00000000-0000-0000-0004-000000000032"), new Guid("00000000-0000-0000-0006-000000000001"), null, new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4193), null, null, null, "Science and environment textbook for Grade 3", "https://picsum.photos/200/300?random=32", true, false, true, null, 240m, "Grade 3 Science Explorer", 240m, 160m, 130, 0, 150, "Pieces (Pcs)", null },
                    { new Guid("00000000-0000-0000-0004-000000000033"), new Guid("00000000-0000-0000-0006-000000000004"), null, new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4200), null, null, null, "Heavy duty school backpack for Grade 3", "https://picsum.photos/200/300?random=33", true, false, true, null, 750m, "Grade 3 School Bag", 650m, 450m, 80, 0, 100, "Pieces (Pcs)", null }
                });

            migrationBuilder.InsertData(
                table: "SchoolKits",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "GradeId", "IsActive", "IsDeleted", "ModifiedBy", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0007-000000000001"), new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4342), null, null, null, "Essential textbooks and stationery bundle for Grade 1", new Guid("00000000-0000-0000-0005-000000000001"), true, false, null, "Grade 1 Standard Kit", null },
                    { new Guid("00000000-0000-0000-0007-000000000002"), new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4346), null, null, null, "Complete academic package including textbooks and journals for Grade 2", new Guid("00000000-0000-0000-0005-000000000002"), true, false, null, "Grade 2 Premium Kit", null },
                    { new Guid("00000000-0000-0000-0007-000000000003"), new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4350), null, null, null, "All required textbooks and school bag for Grade 3", new Guid("00000000-0000-0000-0005-000000000003"), true, false, null, "Grade 3 Classic Kit", null }
                });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.InsertData(
                table: "ItemGrades",
                columns: new[] { "GradeId", "ItemId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0005-000000000001"), new Guid("00000000-0000-0000-0004-000000000011") },
                    { new Guid("00000000-0000-0000-0005-000000000001"), new Guid("00000000-0000-0000-0004-000000000012") },
                    { new Guid("00000000-0000-0000-0005-000000000001"), new Guid("00000000-0000-0000-0004-000000000013") },
                    { new Guid("00000000-0000-0000-0005-000000000003"), new Guid("00000000-0000-0000-0004-000000000031") },
                    { new Guid("00000000-0000-0000-0005-000000000003"), new Guid("00000000-0000-0000-0004-000000000032") },
                    { new Guid("00000000-0000-0000-0005-000000000003"), new Guid("00000000-0000-0000-0004-000000000033") }
                });

            migrationBuilder.InsertData(
                table: "SchoolKitItems",
                columns: new[] { "ItemId", "SchoolKitId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0004-000000000011"), new Guid("00000000-0000-0000-0007-000000000001"), 1 },
                    { new Guid("00000000-0000-0000-0004-000000000012"), new Guid("00000000-0000-0000-0007-000000000001"), 3 },
                    { new Guid("00000000-0000-0000-0004-000000000013"), new Guid("00000000-0000-0000-0007-000000000001"), 1 },
                    { new Guid("00000000-0000-0000-0004-000000000001"), new Guid("00000000-0000-0000-0007-000000000002"), 1 },
                    { new Guid("00000000-0000-0000-0004-000000000002"), new Guid("00000000-0000-0000-0007-000000000002"), 2 },
                    { new Guid("00000000-0000-0000-0004-000000000003"), new Guid("00000000-0000-0000-0007-000000000002"), 1 },
                    { new Guid("00000000-0000-0000-0004-000000000004"), new Guid("00000000-0000-0000-0007-000000000002"), 1 },
                    { new Guid("00000000-0000-0000-0004-000000000005"), new Guid("00000000-0000-0000-0007-000000000002"), 1 },
                    { new Guid("00000000-0000-0000-0004-000000000031"), new Guid("00000000-0000-0000-0007-000000000003"), 1 },
                    { new Guid("00000000-0000-0000-0004-000000000032"), new Guid("00000000-0000-0000-0007-000000000003"), 1 },
                    { new Guid("00000000-0000-0000-0004-000000000033"), new Guid("00000000-0000-0000-0007-000000000003"), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemGrades",
                keyColumns: new[] { "GradeId", "ItemId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0005-000000000001"), new Guid("00000000-0000-0000-0004-000000000011") });

            migrationBuilder.DeleteData(
                table: "ItemGrades",
                keyColumns: new[] { "GradeId", "ItemId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0005-000000000001"), new Guid("00000000-0000-0000-0004-000000000012") });

            migrationBuilder.DeleteData(
                table: "ItemGrades",
                keyColumns: new[] { "GradeId", "ItemId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0005-000000000001"), new Guid("00000000-0000-0000-0004-000000000013") });

            migrationBuilder.DeleteData(
                table: "ItemGrades",
                keyColumns: new[] { "GradeId", "ItemId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0005-000000000003"), new Guid("00000000-0000-0000-0004-000000000031") });

            migrationBuilder.DeleteData(
                table: "ItemGrades",
                keyColumns: new[] { "GradeId", "ItemId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0005-000000000003"), new Guid("00000000-0000-0000-0004-000000000032") });

            migrationBuilder.DeleteData(
                table: "ItemGrades",
                keyColumns: new[] { "GradeId", "ItemId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0005-000000000003"), new Guid("00000000-0000-0000-0004-000000000033") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000011"), new Guid("00000000-0000-0000-0007-000000000001") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000012"), new Guid("00000000-0000-0000-0007-000000000001") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000013"), new Guid("00000000-0000-0000-0007-000000000001") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000001"), new Guid("00000000-0000-0000-0007-000000000002") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000002"), new Guid("00000000-0000-0000-0007-000000000002") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000003"), new Guid("00000000-0000-0000-0007-000000000002") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000004"), new Guid("00000000-0000-0000-0007-000000000002") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000005"), new Guid("00000000-0000-0000-0007-000000000002") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000031"), new Guid("00000000-0000-0000-0007-000000000003") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000032"), new Guid("00000000-0000-0000-0007-000000000003") });

            migrationBuilder.DeleteData(
                table: "SchoolKitItems",
                keyColumns: new[] { "ItemId", "SchoolKitId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0004-000000000033"), new Guid("00000000-0000-0000-0007-000000000003") });

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"));

            migrationBuilder.DeleteData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"));

            migrationBuilder.DeleteData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"));

            migrationBuilder.DeleteData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5081));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CreatedAt", "StockQty", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5195), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CreatedAt", "StockQty", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5202), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CreatedAt", "StockQty", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5209), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CreatedAt", "StockQty", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5215), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CreatedAt", "StorageStatus", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5221), 0, 0 });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 27, 21, 134, DateTimeKind.Utc).AddTicks(5147));
        }
    }
}
