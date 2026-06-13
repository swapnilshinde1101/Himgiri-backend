using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemsToMultipleGrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Grades_GradeId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_GradeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ItemGrades",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    GradeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGrades", x => new { x.ItemId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_ItemGrades_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemGrades_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4232));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4571));

            migrationBuilder.InsertData(
                table: "ItemGrades",
                columns: new[] { "GradeId", "ItemId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0005-000000000002"), new Guid("00000000-0000-0000-0004-000000000001") },
                    { new Guid("00000000-0000-0000-0005-000000000002"), new Guid("00000000-0000-0000-0004-000000000002") },
                    { new Guid("00000000-0000-0000-0005-000000000002"), new Guid("00000000-0000-0000-0004-000000000003") },
                    { new Guid("00000000-0000-0000-0005-000000000002"), new Guid("00000000-0000-0000-0004-000000000004") },
                    { new Guid("00000000-0000-0000-0005-000000000002"), new Guid("00000000-0000-0000-0004-000000000005") }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 18, 39, 10, 487, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.CreateIndex(
                name: "IX_ItemGrades_GradeId",
                table: "ItemGrades",
                column: "GradeId");

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
                                WHEN LOWER(p_SortColumn) = 'mrp' THEN f_Mrp
                                WHEN LOWER(p_SortColumn) = 'stockqty' THEN f_StockQty::NUMERIC
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'price' THEN f_Price
                                WHEN LOWER(p_SortColumn) = 'mrp' THEN f_Mrp
                                WHEN LOWER(p_SortColumn) = 'stockqty' THEN f_StockQty::NUMERIC
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
            migrationBuilder.DropTable(
                name: "ItemGrades");

            migrationBuilder.AddColumn<Guid>(
                name: "GradeId",
                table: "Items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9157));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9621));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9629));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                columns: new[] { "CreatedAt", "GradeId" },
                values: new object[] { new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9728), new Guid("00000000-0000-0000-0005-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                columns: new[] { "CreatedAt", "GradeId" },
                values: new object[] { new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9734), new Guid("00000000-0000-0000-0005-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                columns: new[] { "CreatedAt", "GradeId" },
                values: new object[] { new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9744), new Guid("00000000-0000-0000-0005-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                columns: new[] { "CreatedAt", "GradeId" },
                values: new object[] { new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9749), new Guid("00000000-0000-0000-0005-000000000002") });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                columns: new[] { "CreatedAt", "GradeId" },
                values: new object[] { new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9756), new Guid("00000000-0000-0000-0005-000000000002") });

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 4, 11, 7, 56, 436, DateTimeKind.Utc).AddTicks(9687));

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
                          AND (p_CategoryId IS NULL OR i.""CategoryId"" = p_CategoryId)
                          AND (p_GradeId IS NULL OR i.""GradeId"" = p_GradeId)
                          AND (p_IsActive IS NULL OR i.""IsActive"" = p_IsActive)
                          AND (p_StartDate IS NULL OR i.""CreatedAt"" >= p_StartDate)
                          AND (p_EndDate IS NULL OR i.""CreatedAt"" <= p_EndDate)
                          AND (p_StockStatus IS NULL OR p_StockStatus = '' OR p_StockStatus = 'All'
                               OR (p_StockStatus = 'InStock' AND i.""StockQty"" >= 10)
                               OR (p_StockStatus = 'LowStock' AND i.""StockQty"" > 0 AND i.""StockQty"" < 10)
                               OR (p_StockStatus = 'OutOfStock' AND i.""StockQty"" = 0))
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
                                WHEN LOWER(p_SortColumn) = 'mrp' THEN f_Mrp
                                WHEN LOWER(p_SortColumn) = 'stockqty' THEN f_StockQty::NUMERIC
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'price' THEN f_Price
                                WHEN LOWER(p_SortColumn) = 'mrp' THEN f_Mrp
                                WHEN LOWER(p_SortColumn) = 'stockqty' THEN f_StockQty::NUMERIC
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
