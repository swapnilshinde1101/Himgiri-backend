using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletedAtToItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "Items",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2042));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2669));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2679));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2873) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2885) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2928) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CompletedAt", "CreatedAt" },
                values: new object[] { null, new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 6, 8, 55, 28, 635, DateTimeKind.Utc).AddTicks(2789));

            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged(varchar, varchar, varchar, int, int, boolean, uuid, uuid, boolean, timestamptz, timestamptz, varchar, boolean);");
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION usp_GetItemsPaged(
                    p_SearchTerm VARCHAR,
                    p_SortColumn VARCHAR,
                    p_SortDirection VARCHAR,
                    p_PageNumber INT,
                    p_PageSize INT,
                    p_OnlyInitialized BOOLEAN DEFAULT FALSE,
                    p_CategoryId UUID DEFAULT NULL,
                    p_GradeId UUID DEFAULT NULL,
                    p_IsActive BOOLEAN DEFAULT NULL,
                    p_StartDate TIMESTAMPTZ DEFAULT NULL,
                    p_EndDate TIMESTAMPTZ DEFAULT NULL,
                    p_StockStatus VARCHAR DEFAULT NULL,
                    p_IsCompleted BOOLEAN DEFAULT NULL
                )
                RETURNS TABLE (
                    ""Id"" UUID,
                    ""Name"" VARCHAR,
                    ""Description"" TEXT,
                    ""ImageUrl"" TEXT,
                    ""Price"" NUMERIC,
                    ""PurchasePrice"" NUMERIC,
                    ""Mrp"" NUMERIC,
                    ""CategoryId"" UUID,
                    ""CategoryName"" VARCHAR,
                    ""GradeIds"" TEXT,
                    ""GradeNames"" TEXT,
                    ""Unit"" VARCHAR,
                    ""StorageStatus"" INT,
                    ""StockQty"" INT,
                    ""TargetQty"" INT,
                    ""IsActive"" BOOLEAN,
                    ""IsStockInitialized"" BOOLEAN,
                    ""CreatedAt"" TIMESTAMPTZ,
                    ""CompletedAt"" TIMESTAMPTZ,
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
                            i.""PurchasePrice"" as f_PurchasePrice, 
                            i.""Mrp"" as f_Mrp, 
                            i.""CategoryId"" as f_CategoryId, 
                            c.""Name"" as f_CategoryName, 
                            COALESCE(string_agg(g.""Id""::text, ','), '') as f_GradeIds,
                            COALESCE(string_agg(g.""Name"", ', '), '') as f_GradeNames,
                            i.""Unit"" as f_Unit,
                            i.""StorageStatus"" as f_StorageStatus, 
                            i.""StockQty"" as f_StockQty, 
                            i.""TargetQty"" as f_TargetQty,
                            i.""IsActive"" as f_IsActive, 
                            i.""IsStockInitialized"" as f_IsStockInitialized,
                            i.""CreatedAt"" as f_CreatedAt,
                            i.""CompletedAt"" as f_CompletedAt
                        FROM ""Items"" i
                        JOIN ""ItemCategories"" c ON i.""CategoryId"" = c.""Id""
                        LEFT JOIN ""ItemGrades"" ig ON i.""Id"" = ig.""ItemId""
                        LEFT JOIN ""Grades"" g ON ig.""GradeId"" = g.""Id"" AND g.""IsDeleted"" = FALSE
                        WHERE i.""IsDeleted"" = FALSE
                          AND (p_OnlyInitialized = FALSE OR i.""IsStockInitialized"" = TRUE)
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR i.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%'
                               OR EXISTS (
                                   SELECT 1 FROM ""ItemGrades"" igs 
                                   JOIN ""Grades"" gs ON igs.""GradeId"" = gs.""Id"" 
                                   WHERE igs.""ItemId"" = i.""Id"" AND gs.""IsDeleted"" = FALSE AND gs.""Name"" ILIKE '%' || p_SearchTerm || '%'
                                ))
                          AND (p_CategoryId IS NULL OR i.""CategoryId"" = p_CategoryId)
                          AND (p_GradeId IS NULL OR EXISTS (
                              SELECT 1 FROM ""ItemGrades"" igf 
                              WHERE igf.""ItemId"" = i.""Id"" AND igf.""GradeId"" = p_GradeId
                          ))
                          AND (p_IsActive IS NULL OR i.""IsActive"" = p_IsActive)
                          AND (p_StartDate IS NULL OR i.""CreatedAt"" >= p_StartDate)
                          AND (p_EndDate IS NULL OR i.""CreatedAt"" <= p_EndDate)
                          AND (p_StockStatus IS NULL OR p_StockStatus = '' OR p_StockStatus = 'All'
                               OR (p_StockStatus = 'InStock' AND i.""StockQty"" >= 10)
                               OR (p_StockStatus = 'LowStock' AND i.""StockQty"" > 0 AND i.""StockQty"" < 10)
                               OR (p_StockStatus = 'OutOfStock' AND i.""StockQty"" = 0))
                          AND (p_IsCompleted IS NULL 
                               OR (p_IsCompleted = TRUE AND i.""IsStockInitialized"" = TRUE AND i.""StockQty"" = i.""TargetQty"")
                               OR (p_IsCompleted = FALSE AND (i.""IsStockInitialized"" = FALSE OR i.""StockQty"" < i.""TargetQty"")))
                        GROUP BY 
                            i.""Id"", 
                            i.""Name"", 
                            i.""Description"", 
                            i.""ImageUrl"", 
                            i.""Price"", 
                            i.""PurchasePrice"", 
                            i.""Mrp"", 
                            i.""CategoryId"", 
                            c.""Name"", 
                            i.""Unit"",
                            i.""StorageStatus"", 
                            i.""StockQty"", 
                            i.""TargetQty"", 
                            i.""IsActive"", 
                            i.""IsStockInitialized"", 
                            i.""CreatedAt"",
                            i.""CompletedAt""
                    ),
                    PagedItems AS (
                        SELECT 
                            *,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM FilteredItems
                    )
                    SELECT 
                        f_Id::UUID, 
                        f_Name::VARCHAR, 
                        f_Description::TEXT, 
                        f_ImageUrl::TEXT, 
                        f_Price::NUMERIC, 
                        f_PurchasePrice::NUMERIC, 
                        f_Mrp::NUMERIC, 
                        f_CategoryId::UUID, 
                        f_CategoryName::VARCHAR, 
                        f_GradeIds::TEXT, 
                        f_GradeNames::TEXT, 
                        f_Unit::VARCHAR,
                        f_StorageStatus::INT, 
                        f_StockQty::INT, 
                        f_TargetQty::INT, 
                        f_IsActive::BOOLEAN, 
                        f_IsStockInitialized::BOOLEAN, 
                        f_CreatedAt::TIMESTAMPTZ, 
                        f_CompletedAt::TIMESTAMPTZ, 
                        f_TotalCount::INT
                    FROM PagedItems
                    ORDER BY 
                        -- String sorting
                        CASE WHEN UPPER(p_SortDirection) = 'ASC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'name' THEN f_Name
                                WHEN LOWER(p_SortColumn) = 'categoryname' THEN f_CategoryName
                                WHEN LOWER(p_SortColumn) = 'gradename' THEN f_GradeNames
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'name' THEN f_Name
                                WHEN LOWER(p_SortColumn) = 'categoryname' THEN f_CategoryName
                                WHEN LOWER(p_SortColumn) = 'gradename' THEN f_GradeNames
                            END
                        END DESC,
                        -- Numeric sorting
                        CASE WHEN UPPER(p_SortDirection) = 'ASC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'price' THEN f_Price
                                WHEN LOWER(p_SortColumn) = 'stockqty' THEN f_StockQty::NUMERIC
                                WHEN LOWER(p_SortColumn) = 'targetqty' THEN f_TargetQty::NUMERIC
                                WHEN LOWER(p_SortColumn) = 'mrp' THEN f_Mrp
                                WHEN LOWER(p_SortColumn) = 'purchaseprice' THEN f_PurchasePrice
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'price' THEN f_Price
                                WHEN LOWER(p_SortColumn) = 'stockqty' THEN f_StockQty::NUMERIC
                                WHEN LOWER(p_SortColumn) = 'targetqty' THEN f_TargetQty::NUMERIC
                                WHEN LOWER(p_SortColumn) = 'mrp' THEN f_Mrp
                                WHEN LOWER(p_SortColumn) = 'purchaseprice' THEN f_PurchasePrice
                            END
                        END DESC,
                        -- Date sorting
                        CASE WHEN UPPER(p_SortDirection) = 'ASC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'createdat' THEN f_CreatedAt
                                WHEN LOWER(p_SortColumn) = 'completedat' THEN f_CompletedAt
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'createdat' THEN f_CreatedAt
                                WHEN LOWER(p_SortColumn) = 'completedat' THEN f_CompletedAt
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
                name: "CompletedAt",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9399));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9845));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 47, 26, 145, DateTimeKind.Utc).AddTicks(9737));

            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged(varchar, varchar, varchar, int, int, boolean, uuid, uuid, boolean, timestamptz, timestamptz, varchar, boolean);");
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION usp_GetItemsPaged(
                    p_SearchTerm VARCHAR,
                    p_SortColumn VARCHAR,
                    p_SortDirection VARCHAR,
                    p_PageNumber INT,
                    p_PageSize INT,
                    p_OnlyInitialized BOOLEAN DEFAULT FALSE,
                    p_CategoryId UUID DEFAULT NULL,
                    p_GradeId UUID DEFAULT NULL,
                    p_IsActive BOOLEAN DEFAULT NULL,
                    p_StartDate TIMESTAMPTZ DEFAULT NULL,
                    p_EndDate TIMESTAMPTZ DEFAULT NULL,
                    p_StockStatus VARCHAR DEFAULT NULL,
                    p_IsCompleted BOOLEAN DEFAULT NULL
                )
                RETURNS TABLE (
                    ""Id"" UUID,
                    ""Name"" VARCHAR,
                    ""Description"" TEXT,
                    ""ImageUrl"" TEXT,
                    ""Price"" NUMERIC,
                    ""PurchasePrice"" NUMERIC,
                    ""Mrp"" NUMERIC,
                    ""CategoryId"" UUID,
                    ""CategoryName"" VARCHAR,
                    ""GradeIds"" TEXT,
                    ""GradeNames"" TEXT,
                    ""Unit"" VARCHAR,
                    ""StorageStatus"" INT,
                    ""StockQty"" INT,
                    ""TargetQty"" INT,
                    ""IsActive"" BOOLEAN,
                    ""IsStockInitialized"" BOOLEAN,
                    ""CreatedAt"" TIMESTAMPTZ,
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
                            i.""PurchasePrice"" as f_PurchasePrice, 
                            i.""Mrp"" as f_Mrp, 
                            i.""CategoryId"" as f_CategoryId, 
                            c.""Name"" as f_CategoryName, 
                            COALESCE(string_agg(g.""Id""::text, ','), '') as f_GradeIds,
                            COALESCE(string_agg(g.""Name"", ', '), '') as f_GradeNames,
                            i.""Unit"" as f_Unit,
                            i.""StorageStatus"" as f_StorageStatus, 
                            i.""StockQty"" as f_StockQty, 
                            i.""TargetQty"" as f_TargetQty,
                            i.""IsActive"" as f_IsActive, 
                            i.""IsStockInitialized"" as f_IsStockInitialized,
                            i.""CreatedAt"" as f_CreatedAt
                        FROM ""Items"" i
                        JOIN ""ItemCategories"" c ON i.""CategoryId"" = c.""Id""
                        LEFT JOIN ""ItemGrades"" ig ON i.""Id"" = ig.""ItemId""
                        LEFT JOIN ""Grades"" g ON ig.""GradeId"" = g.""Id"" AND g.""IsDeleted"" = FALSE
                        WHERE i.""IsDeleted"" = FALSE
                          AND (p_OnlyInitialized = FALSE OR i.""IsStockInitialized"" = TRUE)
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR i.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%'
                               OR EXISTS (
                                   SELECT 1 FROM ""ItemGrades"" igs 
                                   JOIN ""Grades"" gs ON igs.""GradeId"" = gs.""Id"" 
                                   WHERE igs.""ItemId"" = i.""Id"" AND gs.""IsDeleted"" = FALSE AND gs.""Name"" ILIKE '%' || p_SearchTerm || '%'
                                ))
                          AND (p_CategoryId IS NULL OR i.""CategoryId"" = p_CategoryId)
                          AND (p_GradeId IS NULL OR EXISTS (
                              SELECT 1 FROM ""ItemGrades"" igf 
                              WHERE igf.""ItemId"" = i.""Id"" AND igf.""GradeId"" = p_GradeId
                          ))
                          AND (p_IsActive IS NULL OR i.""IsActive"" = p_IsActive)
                          AND (p_StartDate IS NULL OR i.""CreatedAt"" >= p_StartDate)
                          AND (p_EndDate IS NULL OR i.""CreatedAt"" <= p_EndDate)
                          AND (p_StockStatus IS NULL OR p_StockStatus = '' OR p_StockStatus = 'All'
                               OR (p_StockStatus = 'InStock' AND i.""StockQty"" >= 10)
                               OR (p_StockStatus = 'LowStock' AND i.""StockQty"" > 0 AND i.""StockQty"" < 10)
                               OR (p_StockStatus = 'OutOfStock' AND i.""StockQty"" = 0))
                          AND (p_IsCompleted IS NULL 
                               OR (p_IsCompleted = TRUE AND i.""IsStockInitialized"" = TRUE AND i.""StockQty"" = i.""TargetQty"")
                               OR (p_IsCompleted = FALSE AND (i.""IsStockInitialized"" = FALSE OR i.""StockQty"" < i.""TargetQty"")))
                        GROUP BY 
                            i.""Id"", 
                            i.""Name"", 
                            i.""Description"", 
                            i.""ImageUrl"", 
                            i.""Price"", 
                            i.""PurchasePrice"", 
                            i.""Mrp"", 
                            i.""CategoryId"", 
                            c.""Name"", 
                            i.""Unit"",
                            i.""StorageStatus"", 
                            i.""StockQty"", 
                            i.""TargetQty"", 
                            i.""IsActive"", 
                            i.""IsStockInitialized"", 
                            i.""CreatedAt""
                    ),
                    PagedItems AS (
                        SELECT 
                            *,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM FilteredItems
                    )
                    SELECT 
                        f_Id::UUID, 
                        f_Name::VARCHAR, 
                        f_Description::TEXT, 
                        f_ImageUrl::TEXT, 
                        f_Price::NUMERIC, 
                        f_PurchasePrice::NUMERIC, 
                        f_Mrp::NUMERIC, 
                        f_CategoryId::UUID, 
                        f_CategoryName::VARCHAR, 
                        f_GradeIds::TEXT, 
                        f_GradeNames::TEXT, 
                        f_Unit::VARCHAR,
                        f_StorageStatus::INT, 
                        f_StockQty::INT, 
                        f_TargetQty::INT, 
                        f_IsActive::BOOLEAN, 
                        f_IsStockInitialized::BOOLEAN, 
                        f_CreatedAt::TIMESTAMPTZ, 
                        f_TotalCount::INT
                    FROM PagedItems
                    ORDER BY 
                        -- String sorting
                        CASE WHEN UPPER(p_SortDirection) = 'ASC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'name' THEN f_Name
                                WHEN LOWER(p_SortColumn) = 'categoryname' THEN f_CategoryName
                                WHEN LOWER(p_SortColumn) = 'gradename' THEN f_GradeNames
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'name' THEN f_Name
                                WHEN LOWER(p_SortColumn) = 'categoryname' THEN f_CategoryName
                                WHEN LOWER(p_SortColumn) = 'gradename' THEN f_GradeNames
                            END
                        END DESC,
                        -- Numeric sorting
                        CASE WHEN UPPER(p_SortDirection) = 'ASC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'price' THEN f_Price
                                WHEN LOWER(p_SortColumn) = 'stockqty' THEN f_StockQty::NUMERIC
                                WHEN LOWER(p_SortColumn) = 'targetqty' THEN f_TargetQty::NUMERIC
                                WHEN LOWER(p_SortColumn) = 'mrp' THEN f_Mrp
                                WHEN LOWER(p_SortColumn) = 'purchaseprice' THEN f_PurchasePrice
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'price' THEN f_Price
                                WHEN LOWER(p_SortColumn) = 'stockqty' THEN f_StockQty::NUMERIC
                                WHEN LOWER(p_SortColumn) = 'targetqty' THEN f_TargetQty::NUMERIC
                                WHEN LOWER(p_SortColumn) = 'mrp' THEN f_Mrp
                                WHEN LOWER(p_SortColumn) = 'purchaseprice' THEN f_PurchasePrice
                            END
                        END DESC,
                        -- Date sorting
                        CASE WHEN UPPER(p_SortDirection) = 'ASC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'createdat' THEN f_CreatedAt
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'createdat' THEN f_CreatedAt
                            END
                        END DESC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");
        }
    }
}
