using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemsSPForNewSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ── Update Stored Procedure for new schema (No Stock fields) ──
            // Postgres requires a DROP before changing return columns
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
                    ""ImageUrl"" TEXT,
                    ""Price"" DECIMAL,
                    ""CategoryId"" UUID,
                    ""CategoryName"" VARCHAR,
                    ""GradeId"" UUID,
                    ""GradeName"" VARCHAR,
                    ""IsActive"" BOOLEAN,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredItems AS (
                        SELECT 
                            i.""Id"" as f_Id, 
                            i.""Name"" as f_Name, 
                            i.""Description"" as f_Description, 
                            i.""ImageUrl"" as f_ImageUrl, 
                            i.""Price"" as f_Price, 
                            i.""CategoryId"" as f_CategoryId, 
                            c.""Name"" as f_CategoryName, 
                            i.""GradeId"" as f_GradeId, 
                            g.""Name"" as f_GradeName, 
                            i.""IsActive"" as f_IsActive,
                            COUNT(*) OVER()::INT as f_TotalCount
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
                        CASE WHEN LOWER(p_SortColumn) = 'name' AND UPPER(p_SortDirection) = 'ASC' THEN f_Name END ASC,
                        CASE WHEN LOWER(p_SortColumn) = 'name' AND UPPER(p_SortDirection) = 'DESC' THEN f_Name END DESC,
                        CASE WHEN LOWER(p_SortColumn) = 'price' AND UPPER(p_SortDirection) = 'ASC' THEN f_Price END ASC,
                        CASE WHEN LOWER(p_SortColumn) = 'price' AND UPPER(p_SortDirection) = 'DESC' THEN f_Price END DESC
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
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(6227));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7685));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7896));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7918));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7799));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged;");
        }
    }
}
