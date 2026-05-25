using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SyncGradesAndCategoriesSPs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ── 1. Update usp_GetGradesPaged (Sync with SpGetGradesPagedResult) ──
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetGradesPaged(VARCHAR, INT, INT);");
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION usp_GetGradesPaged(
                    p_SearchTerm VARCHAR,
                    p_PageNumber INT,
                    p_PageSize INT
                )
                RETURNS TABLE (
                    ""Id"" UUID,
                    ""Name"" VARCHAR,
                    ""ShortName"" VARCHAR,
                    ""Description"" TEXT,
                    ""DisplayOrder"" INT,
                    ""IsActive"" BOOLEAN,
                    ""CreatedAt"" TIMESTAMPTZ,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredGrades AS (
                        SELECT 
                            g.""Id"" as f_Id, 
                            g.""Name"" as f_Name, 
                            g.""ShortName"" as f_ShortName, 
                            g.""Description"" as f_Description,
                            g.""DisplayOrder"" as f_DisplayOrder, 
                            g.""IsActive"" as f_IsActive,
                            g.""CreatedAt"" as f_CreatedAt,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM ""Grades"" g
                        WHERE g.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR g.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR g.""ShortName"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT 
                        f_Id::UUID, 
                        f_Name::VARCHAR, 
                        f_ShortName::VARCHAR, 
                        f_Description::TEXT,
                        f_DisplayOrder::INT, 
                        f_IsActive::BOOLEAN, 
                        f_CreatedAt::TIMESTAMPTZ,
                        f_TotalCount::INT
                    FROM FilteredGrades
                    ORDER BY f_DisplayOrder ASC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");

            // ── 2. Update usp_GetCategoriesPaged (Sync with SpGetCategoriesPagedResult) ──
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetCategoriesPaged(VARCHAR, INT, INT);");
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION usp_GetCategoriesPaged(
                    p_SearchTerm VARCHAR,
                    p_PageNumber INT,
                    p_PageSize INT
                )
                RETURNS TABLE (
                    ""Id"" UUID,
                    ""Name"" VARCHAR,
                    ""Description"" TEXT,
                    ""IsActive"" BOOLEAN,
                    ""DisplayOrder"" INT,
                    ""HsnCode"" VARCHAR,
                    ""GstPercent"" NUMERIC,
                    ""CgstPercent"" NUMERIC,
                    ""SgstPercent"" NUMERIC,
                    ""IsTaxable"" BOOLEAN,
                    ""CreatedAt"" TIMESTAMPTZ,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredCats AS (
                        SELECT 
                            c.""Id"" as f_Id, 
                            c.""Name"" as f_Name, 
                            c.""Description"" as f_Description,
                            c.""IsActive"" as f_IsActive,
                            c.""DisplayOrder"" as f_DisplayOrder,
                            c.""HsnCode"" as f_HsnCode, 
                            c.""GstPercent"" as f_GstPercent, 
                            c.""CgstPercent"" as f_CgstPercent, 
                            c.""SgstPercent"" as f_SgstPercent, 
                            c.""IsTaxable"" as f_IsTaxable,
                            c.""CreatedAt"" as f_CreatedAt,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM ""ItemCategories"" c
                        WHERE c.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR c.""HsnCode"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT 
                        f_Id::UUID, 
                        f_Name::VARCHAR, 
                        f_Description::TEXT,
                        f_IsActive::BOOLEAN, 
                        f_DisplayOrder::INT,
                        f_HsnCode::VARCHAR, 
                        f_GstPercent::NUMERIC, 
                        f_CgstPercent::NUMERIC, 
                        f_SgstPercent::NUMERIC, 
                        f_IsTaxable::BOOLEAN,
                        f_CreatedAt::TIMESTAMPTZ,
                        f_TotalCount::INT
                    FROM FilteredCats
                    ORDER BY f_DisplayOrder ASC, f_Name ASC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7259));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7264));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7619));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7854));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 25, 6, 52, 51, 454, DateTimeKind.Utc).AddTicks(7813));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpGetCategoriesPagedResults",
                columns: table => new
                {
                    CgstPercent = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    GstPercent = table.Column<decimal>(type: "numeric", nullable: false),
                    HsnCode = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsTaxable = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SgstPercent = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SpGetGradesPagedResults",
                columns: table => new
                {
                    Description = table.Column<string>(type: "text", nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false),
                    TotalCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SpGetItemsPagedResults",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    GradeId = table.Column<Guid>(type: "uuid", nullable: false),
                    GradeName = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    StockQty = table.Column<int>(type: "integer", nullable: false),
                    StorageStatus = table.Column<int>(type: "integer", nullable: false),
                    TotalCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(1908));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4250));
        }
    }
}
