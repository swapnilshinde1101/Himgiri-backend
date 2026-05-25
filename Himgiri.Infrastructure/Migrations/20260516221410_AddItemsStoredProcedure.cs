using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddItemsStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6428));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6632));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6636));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 14, 8, 149, DateTimeKind.Utc).AddTicks(6674));

            // ── Custom Stored Procedure ──
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
                    ""ImageUrl"" TEXT,
                    ""Price"" DECIMAL,
                    ""CategoryId"" UUID,
                    ""CategoryName"" VARCHAR,
                    ""GradeId"" UUID,
                    ""GradeName"" VARCHAR,
                    ""StockQty"" INT,
                    ""StorageStatus"" INT,
                    ""IsActive"" BOOLEAN,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredItems AS (
                        SELECT 
                            i.""Id"", i.""Name"", i.""Description"", i.""ImageUrl"", i.""Price"", 
                            i.""CategoryId"", c.""Name"" as ""CategoryName"", 
                            i.""GradeId"", g.""Name"" as ""GradeName"", 
                            i.""StockQty"", CAST(i.""StorageStatus"" AS INT) as ""StorageStatus"", i.""IsActive"",
                            COUNT(*) OVER()::INT as ""TotalCount""
                        FROM ""Items"" i
                        INNER JOIN ""ItemCategories"" c ON i.""CategoryId"" = c.""Id""
                        INNER JOIN ""Grades"" g ON i.""GradeId"" = g.""Id""
                        WHERE i.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR i.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR i.""Description"" ILIKE '%' || p_SearchTerm || '%'
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT * FROM FilteredItems
                    ORDER BY
                        CASE WHEN LOWER(p_SortColumn) = 'name' AND UPPER(p_SortDirection) = 'ASC' THEN ""Name"" END ASC,
                        CASE WHEN LOWER(p_SortColumn) = 'name' AND UPPER(p_SortDirection) = 'DESC' THEN ""Name"" END DESC,
                        CASE WHEN LOWER(p_SortColumn) = 'price' AND UPPER(p_SortDirection) = 'ASC' THEN ""Price"" END ASC,
                        CASE WHEN LOWER(p_SortColumn) = 'price' AND UPPER(p_SortDirection) = 'DESC' THEN ""Price"" END DESC,
                        CASE WHEN LOWER(p_SortColumn) = 'stock' AND UPPER(p_SortDirection) = 'ASC' THEN ""StockQty"" END ASC,
                        CASE WHEN LOWER(p_SortColumn) = 'stock' AND UPPER(p_SortDirection) = 'DESC' THEN ""StockQty"" END DESC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged;");
            
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1525));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1531));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1538));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1850));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 16, 22, 3, 42, 901, DateTimeKind.Utc).AddTicks(1805));
        }
    }
}
