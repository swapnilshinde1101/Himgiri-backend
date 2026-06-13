using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsStockInitializedFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStockInitialized",
                table: "Items",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(4672));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(4716));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CreatedAt", "IsStockInitialized" },
                values: new object[] { new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5827), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CreatedAt", "IsStockInitialized" },
                values: new object[] { new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5842), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CreatedAt", "IsStockInitialized" },
                values: new object[] { new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5857), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CreatedAt", "IsStockInitialized" },
                values: new object[] { new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5876), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CreatedAt", "IsStockInitialized" },
                values: new object[] { new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5885), true });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 6, 39, 30, 458, DateTimeKind.Utc).AddTicks(5747));

            // Update usp_GetItemsPaged stored procedure to return IsStockInitialized column and accept p_OnlyInitialized filter
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged(VARCHAR, VARCHAR, VARCHAR, INT, INT);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged(VARCHAR, VARCHAR, VARCHAR, INT, INT, BOOLEAN);");
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION usp_GetItemsPaged(
                    p_SearchTerm VARCHAR,
                    p_SortColumn VARCHAR,
                    p_SortDirection VARCHAR,
                    p_PageNumber INT,
                    p_PageSize INT,
                    p_OnlyInitialized BOOLEAN DEFAULT FALSE
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
                    ""GradeId"" UUID,
                    ""GradeName"" VARCHAR,
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
                            i.""GradeId"" as f_GradeId, 
                            g.""Name"" as f_GradeName,
                            i.""StorageStatus"" as f_StorageStatus, 
                            i.""StockQty"" as f_StockQty, 
                            i.""IsActive"" as f_IsActive, 
                            i.""IsStockInitialized"" as f_IsStockInitialized,
                            i.""CreatedAt"" as f_CreatedAt,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM ""Items"" i
                        JOIN ""ItemCategories"" c ON i.""CategoryId"" = c.""Id""
                        JOIN ""Grades"" g ON i.""GradeId"" = g.""Id""
                        WHERE i.""IsDeleted"" = FALSE
                          AND (p_OnlyInitialized = FALSE OR i.""IsStockInitialized"" = TRUE)
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR i.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%'
                               OR g.""Name"" ILIKE '%' || p_SearchTerm || '%')
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
                        f_GradeId::UUID, 
                        f_GradeName::VARCHAR, 
                        f_StorageStatus::INT, 
                        f_StockQty::INT, 
                        f_IsActive::BOOLEAN, 
                        f_IsStockInitialized::BOOLEAN, 
                        f_CreatedAt::TIMESTAMPTZ, 
                        f_TotalCount::INT
                    FROM FilteredItems
                    ORDER BY 
                        -- String sorting
                        CASE WHEN UPPER(p_SortDirection) = 'ASC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'name' THEN f_Name
                                WHEN LOWER(p_SortColumn) = 'categoryname' THEN f_CategoryName
                                WHEN LOWER(p_SortColumn) = 'gradename' THEN f_GradeName
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'name' THEN f_Name
                                WHEN LOWER(p_SortColumn) = 'categoryname' THEN f_CategoryName
                                WHEN LOWER(p_SortColumn) = 'gradename' THEN f_GradeName
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStockInitialized",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(374));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(378));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(383));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(967));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(971));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(973));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(974));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(1071));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 3, 18, 20, 21, 298, DateTimeKind.Utc).AddTicks(1029));

            // Restore usp_GetItemsPaged to original definition without the p_OnlyInitialized filter and column
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged(VARCHAR, VARCHAR, VARCHAR, INT, INT);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged(VARCHAR, VARCHAR, VARCHAR, INT, INT, BOOLEAN);");
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
                    ""Price"" NUMERIC,
                    ""PurchasePrice"" NUMERIC,
                    ""Mrp"" NUMERIC,
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
                            i.""Id"" as f_Id, 
                            i.""Name"" as f_Name, 
                            i.""Description"" as f_Description, 
                            i.""ImageUrl"" as f_ImageUrl, 
                            i.""Price"" as f_Price, 
                            i.""PurchasePrice"" as f_PurchasePrice, 
                            i.""Mrp"" as f_Mrp, 
                            i.""CategoryId"" as f_CategoryId, 
                            c.""Name"" as f_CategoryName, 
                            i.""GradeId"" as f_GradeId, 
                            g.""Name"" as f_GradeName,
                            i.""StorageStatus"" as f_StorageStatus, 
                            i.""StockQty"" as f_StockQty, 
                            i.""IsActive"" as f_IsActive, 
                            i.""CreatedAt"" as f_CreatedAt,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM ""Items"" i
                        JOIN ""ItemCategories"" c ON i.""CategoryId"" = c.""Id""
                        JOIN ""Grades"" g ON i.""GradeId"" = g.""Id""
                        WHERE i.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR i.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%'
                               OR g.""Name"" ILIKE '%' || p_SearchTerm || '%')
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
                        f_GradeId::UUID, 
                        f_GradeName::VARCHAR, 
                        f_StorageStatus::INT, 
                        f_StockQty::INT, 
                        f_IsActive::BOOLEAN, 
                        f_CreatedAt::TIMESTAMPTZ, 
                        f_TotalCount::INT
                    FROM FilteredItems
                    ORDER BY 
                        -- String sorting
                        CASE WHEN UPPER(p_SortDirection) = 'ASC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'name' THEN f_Name
                                WHEN LOWER(p_SortColumn) = 'categoryname' THEN f_CategoryName
                                WHEN LOWER(p_SortColumn) = 'gradename' THEN f_GradeName
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'name' THEN f_Name
                                WHEN LOWER(p_SortColumn) = 'categoryname' THEN f_CategoryName
                                WHEN LOWER(p_SortColumn) = 'gradename' THEN f_GradeName
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
        }
    }
}
