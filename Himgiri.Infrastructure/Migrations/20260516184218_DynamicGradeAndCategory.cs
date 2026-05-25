using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DynamicGradeAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GstSettings");

            migrationBuilder.DropIndex(
                name: "IX_Items_Grade",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "GstPercent",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HsnCode",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GradeId",
                table: "Items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HsnCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    GstPercent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    CgstPercent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    SgstPercent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    IsTaxable = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(730));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(740));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(745));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(754));

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "DisplayOrder", "IsActive", "IsDeleted", "ModifiedBy", "Name", "ShortName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0005-000000000001"), new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(978), null, null, null, 1, true, false, null, "Grade 1", "G1", null },
                    { new Guid("00000000-0000-0000-0005-000000000002"), new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(983), null, null, null, 2, true, false, null, "Grade 2", "G2", null },
                    { new Guid("00000000-0000-0000-0005-000000000003"), new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(989), null, null, null, 3, true, false, null, "Grade 3", "G3", null }
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "Id", "CgstPercent", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "GstPercent", "HsnCode", "IsActive", "IsDeleted", "IsTaxable", "ModifiedBy", "Name", "SgstPercent", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0006-000000000001"), 0m, new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1031), null, null, null, 0m, "4901", true, false, true, null, "Textbook", 0m, null },
                    { new Guid("00000000-0000-0000-0006-000000000002"), 6m, new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1037), null, null, null, 12m, "4820", true, false, true, null, "Stationery", 6m, null },
                    { new Guid("00000000-0000-0000-0006-000000000003"), 6m, new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1039), null, null, null, 12m, "4820", true, false, true, null, "Journal", 6m, null },
                    { new Guid("00000000-0000-0000-0006-000000000004"), 9m, new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1040), null, null, null, 18m, "4202", true, false, true, null, "Bag", 9m, null },
                    { new Guid("00000000-0000-0000-0006-000000000005"), 9m, new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1043), null, null, null, 18m, "9965", true, false, true, null, "Delivery Fee", 9m, null }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CategoryId", "CreatedAt", "GradeId" },
                values: new object[] { new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1158), new Guid("00000000-0000-0000-0005-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CategoryId", "CreatedAt", "GradeId" },
                values: new object[] { new Guid("00000000-0000-0000-0006-000000000002"), new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1165), new Guid("00000000-0000-0000-0005-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CategoryId", "CreatedAt", "GradeId" },
                values: new object[] { new Guid("00000000-0000-0000-0006-000000000003"), new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1171), new Guid("00000000-0000-0000-0005-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CategoryId", "CreatedAt", "Description", "GradeId" },
                values: new object[] { new Guid("00000000-0000-0000-0006-000000000001"), new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1177), "Marathi Theme Book", new Guid("00000000-0000-0000-0005-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CategoryId", "CreatedAt", "Description", "GradeId" },
                values: new object[] { new Guid("00000000-0000-0000-0006-000000000001"), new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1183), "Grade 2 Theme Book", new Guid("00000000-0000-0000-0005-000000000002") });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 18, 42, 11, 460, DateTimeKind.Utc).AddTicks(1113));

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_GradeId",
                table: "Items",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Grades_GradeId",
                table: "Items",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCategories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Grades_GradeId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCategories_CategoryId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_GradeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "GstPercent",
                table: "Items",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "HsnCode",
                table: "Items",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GstSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    CgstPercent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    EffectiveFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GstPercent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    HsnCode = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    SgstPercent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GstSettings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3357));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3361));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3364));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3370));

            migrationBuilder.InsertData(
                table: "GstSettings",
                columns: new[] { "Id", "Category", "CgstPercent", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "EffectiveFrom", "GstPercent", "HsnCode", "IsActive", "IsDeleted", "ModifiedBy", "SgstPercent", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0002-000000000001"), 0, 0m, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3559), null, null, null, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3549), 0m, "4901", true, false, null, 0m, null },
                    { new Guid("00000000-0000-0000-0002-000000000002"), 3, 6m, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3565), null, null, null, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3560), 12m, "4820", true, false, null, 6m, null },
                    { new Guid("00000000-0000-0000-0002-000000000003"), 1, 6m, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3569), null, null, null, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3566), 12m, "4820", true, false, null, 6m, null },
                    { new Guid("00000000-0000-0000-0002-000000000004"), 2, 9m, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3576), null, null, null, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3570), 18m, "4202", true, false, null, 9m, null },
                    { new Guid("00000000-0000-0000-0002-000000000005"), 4, 9m, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3579), null, null, null, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3577), 18m, "9965", true, false, null, 9m, null }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "Category", "CreatedAt", "Grade", "GstPercent", "HsnCode" },
                values: new object[] { 3, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3643), 2, 12m, "4820" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "Category", "CreatedAt", "Grade", "GstPercent", "HsnCode" },
                values: new object[] { 1, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3648), 2, 12m, "4820" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "Category", "CreatedAt", "Grade", "GstPercent", "HsnCode" },
                values: new object[] { 3, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3652), 2, 12m, "4820" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "Category", "CreatedAt", "Description", "Grade", "GstPercent", "HsnCode" },
                values: new object[] { 0, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3656), "Marathi Theme Book — delivered to classroom June 2026", 2, 0m, "4901" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "Category", "CreatedAt", "Description", "Grade", "GstPercent", "HsnCode" },
                values: new object[] { 0, new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3660), "Grade 2 Theme Book — delivered to classroom June 2026", 2, 0m, "4901" });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 12, 51, 23, 384, DateTimeKind.Utc).AddTicks(3612));

            migrationBuilder.CreateIndex(
                name: "IX_Items_Grade",
                table: "Items",
                column: "Grade");
        }
    }
}
