using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStockFieldsToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockQty",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageStatus",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CreatedAt", "StockQty", "StorageStatus" },
                values: new object[] { new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4628), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CreatedAt", "StockQty", "StorageStatus" },
                values: new object[] { new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4636), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CreatedAt", "StockQty", "StorageStatus" },
                values: new object[] { new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4642), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CreatedAt", "StockQty", "StorageStatus" },
                values: new object[] { new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4672), 0, 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CreatedAt", "StockQty", "StorageStatus" },
                values: new object[] { new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4681), 0, 0 });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 7, 0, 50, 463, DateTimeKind.Utc).AddTicks(4250));

            // ── Update usp_GetItemsPaged ──
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged(VARCHAR, VARCHAR, VARCHAR, INT, INT);");
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION usp_GetItemsPaged(
                    p_SearchTerm VARCHAR,
                    p_SortColumn VARCHAR,
                    p_SortDirection VARCHAR,
                    p_PageNumber INT,
                    p_PageSize INT
                )
                RETURNS TABLE (
                    ""Id"" UUID,
                    ""Name"" VARCHAR,
                    ""Description"" TEXT,
                    ""ImageUrl"" VARCHAR,
                    ""Price"" DECIMAL,
                    ""CategoryId"" UUID,
                    ""CategoryName"" VARCHAR,
                    ""GradeId"" UUID,
                    ""GradeName"" VARCHAR,
                    ""StorageStatus"" INT,
                    ""StockQty"" INT,
                    ""IsActive"" BOOLEAN,
                    ""CreatedAt"" TIMESTAMPTZ,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredItems AS (
                        SELECT 
                            i.""Id"", i.""Name"", i.""Description"", i.""ImageUrl"", i.""Price"", 
                            i.""CategoryId"", c.""Name"" as ""CategoryName"", 
                            i.""GradeId"", g.""Name"" as ""GradeName"",
                            i.""StorageStatus"", i.""StockQty"", i.""IsActive"", i.""CreatedAt"",
                            COUNT(*) OVER()::INT as ""TotalCount""
                        FROM ""Items"" i
                        JOIN ""ItemCategories"" c ON i.""CategoryId"" = c.""Id""
                        JOIN ""Grades"" g ON i.""GradeId"" = g.""Id""
                        WHERE i.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR i.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%'
                               OR g.""Name"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT f.* FROM FilteredItems f
                    ORDER BY 
                        CASE WHEN p_SortDirection = 'ASC' THEN
                            CASE 
                                WHEN p_SortColumn = 'name' THEN f.""Name""
                                WHEN p_SortColumn = 'categoryName' THEN f.""CategoryName""
                                WHEN p_SortColumn = 'gradeName' THEN f.""GradeName""
                            END
                        END ASC,
                        CASE WHEN p_SortDirection = 'DESC' THEN
                            CASE 
                                WHEN p_SortColumn = 'name' THEN f.""Name""
                                WHEN p_SortColumn = 'categoryName' THEN f.""CategoryName""
                                WHEN p_SortColumn = 'gradeName' THEN f.""GradeName""
                            END
                        END DESC,
                        CASE WHEN p_SortDirection = 'ASC' THEN
                            CASE 
                                WHEN p_SortColumn = 'price' THEN f.""Price""
                                WHEN p_SortColumn = 'stockQty' THEN f.""StockQty""
                                WHEN p_SortColumn = 'CreatedAt' THEN f.""CreatedAt""::TEXT
                            END
                        END ASC,
                        CASE WHEN p_SortDirection = 'DESC' THEN
                            CASE 
                                WHEN p_SortColumn = 'price' THEN f.""Price""
                                WHEN p_SortColumn = 'stockQty' THEN f.""StockQty""
                                WHEN p_SortColumn = 'CreatedAt' THEN f.""CreatedAt""::TEXT
                            END
                        END DESC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockQty",
                table: "SpGetItemsPagedResults");

            migrationBuilder.DropColumn(
                name: "StorageStatus",
                table: "SpGetItemsPagedResults");

            migrationBuilder.DropColumn(
                name: "StockQty",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StorageStatus",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2348));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2374));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2375));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2413));
        }
    }
}
