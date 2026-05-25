using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixAmbiguousColumnInSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ── Custom Stored Procedure (FIXED AMBIGUITY) ──
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
                            i.""Id"" as f_Id, 
                            i.""Name"" as f_Name, 
                            i.""Description"" as f_Description, 
                            i.""ImageUrl"" as f_ImageUrl, 
                            i.""Price"" as f_Price, 
                            i.""CategoryId"" as f_CategoryId, 
                            c.""Name"" as f_CategoryName, 
                            i.""GradeId"" as f_GradeId, 
                            g.""Name"" as f_GradeName, 
                            i.""StockQty"" as f_StockQty, 
                            CAST(i.""StorageStatus"" AS INT) as f_StorageStatus, 
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
                        CASE WHEN LOWER(p_SortColumn) = 'price' AND UPPER(p_SortDirection) = 'DESC' THEN f_Price END DESC,
                        CASE WHEN LOWER(p_SortColumn) = 'stock' AND UPPER(p_SortDirection) = 'ASC' THEN f_StockQty END ASC,
                        CASE WHEN LOWER(p_SortColumn) = 'stock' AND UPPER(p_SortDirection) = 'DESC' THEN f_StockQty END DESC
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
        }
    }
}
