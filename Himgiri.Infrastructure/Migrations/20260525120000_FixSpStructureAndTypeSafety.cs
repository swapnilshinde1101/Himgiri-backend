using System;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    [DbContext(typeof(HimgiriDbContext))]
    [Migration("20260525120000_FixSpStructureAndTypeSafety")]
    public partial class FixSpStructureAndTypeSafety : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ── 1. Fix usp_GetItemsPaged (Explicit column matching and type casting) ──
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
                    ""Price"" NUMERIC,
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
                            END
                        END ASC,
                        CASE WHEN UPPER(p_SortDirection) = 'DESC' THEN
                            CASE 
                                WHEN LOWER(p_SortColumn) = 'price' THEN f_Price
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

            // ── 2. Fix usp_GetGradesPaged ──
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
                    ""DisplayOrder"" INT,
                    ""IsActive"" BOOLEAN,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredGrades AS (
                        SELECT 
                            g.""Id"" as f_Id, g.""Name"" as f_Name, g.""ShortName"" as f_ShortName, 
                            g.""DisplayOrder"" as f_DisplayOrder, g.""IsActive"" as f_IsActive,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM ""Grades"" g
                        WHERE g.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR g.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR g.""ShortName"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT 
                        f_Id::UUID, f_Name::VARCHAR, f_ShortName::VARCHAR, 
                        f_DisplayOrder::INT, f_IsActive::BOOLEAN, f_TotalCount::INT
                    FROM FilteredGrades
                    ORDER BY f_DisplayOrder ASC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");

            // ── 3. Fix usp_GetCategoriesPaged ──
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
                    ""HsnCode"" VARCHAR,
                    ""GstPercent"" NUMERIC,
                    ""CgstPercent"" NUMERIC,
                    ""SgstPercent"" NUMERIC,
                    ""IsActive"" BOOLEAN,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredCats AS (
                        SELECT 
                            c.""Id"" as f_Id, c.""Name"" as f_Name, c.""HsnCode"" as f_HsnCode, 
                            c.""GstPercent"" as f_GstPercent, c.""CgstPercent"" as f_CgstPercent, 
                            c.""SgstPercent"" as f_SgstPercent, c.""IsActive"" as f_IsActive,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM ""ItemCategories"" c
                        WHERE c.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR c.""HsnCode"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT 
                        f_Id::UUID, f_Name::VARCHAR, f_HsnCode::VARCHAR, 
                        f_GstPercent::NUMERIC, f_CgstPercent::NUMERIC, f_SgstPercent::NUMERIC, 
                        f_IsActive::BOOLEAN, f_TotalCount::INT
                    FROM FilteredCats
                    ORDER BY f_Name ASC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetItemsPaged(VARCHAR, VARCHAR, VARCHAR, INT, INT);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetGradesPaged(VARCHAR, INT, INT);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetCategoriesPaged(VARCHAR, INT, INT);");
        }
    }
}
