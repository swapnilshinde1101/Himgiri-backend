using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTargetQtyToItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TargetQty",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5101));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5128));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5563));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5564));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CreatedAt", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5879), 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CreatedAt", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5891), 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CreatedAt", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5901), 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CreatedAt", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5922), 0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CreatedAt", "TargetQty" },
                values: new object[] { new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5931), 0 });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 5, 18, 1, 33, 152, DateTimeKind.Utc).AddTicks(5796));

            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged(varchar, varchar, varchar, int, int, boolean, uuid, uuid, boolean, timestamptz, timestamptz, varchar);");
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
                    p_StockStatus VARCHAR DEFAULT NULL
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged(varchar, varchar, varchar, int, int, boolean, uuid, uuid, boolean, timestamptz, timestamptz, varchar);");
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
                    p_StockStatus VARCHAR DEFAULT NULL
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
                                WHEN LOWER(p_SortColumn) = 'mrp' THEN f_Mrp
                                WHEN LOWER(p_SortColumn) = 'purchaseprice' THEN f_PurchasePrice
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'price' THEN f_Price
                                WHEN LOWER(p_SortColumn) = 'stockqty' THEN f_StockQty::NUMERIC
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

            migrationBuilder.DropColumn(
                name: "TargetQty",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6419));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6529));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6534));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6535));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6538));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6635));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6647));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 19, 29, 18, 485, DateTimeKind.Utc).AddTicks(6592));
        }
    }
}
