using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMasterPagedProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ── usp_GetGradesPaged ──
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
                            g.""Id"", g.""Name"", g.""ShortName"", g.""DisplayOrder"", g.""IsActive"",
                            COUNT(*) OVER()::INT as ""TotalCount""
                        FROM ""Grades"" g
                        WHERE g.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR g.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR g.""ShortName"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT * FROM FilteredGrades
                    ORDER BY ""DisplayOrder"" ASC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");

            // ── usp_GetCategoriesPaged ──
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
                    ""GstPercent"" DECIMAL,
                    ""CgstPercent"" DECIMAL,
                    ""SgstPercent"" DECIMAL,
                    ""IsActive"" BOOLEAN,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredCats AS (
                        SELECT 
                            c.""Id"", c.""Name"", c.""HsnCode"", c.""GstPercent"", c.""CgstPercent"", c.""SgstPercent"", c.""IsActive"",
                            COUNT(*) OVER()::INT as ""TotalCount""
                        FROM ""ItemCategories"" c
                        WHERE c.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR c.""HsnCode"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT * FROM FilteredCats
                    ORDER BY ""Name"" ASC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetGradesPaged;");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetCategoriesPaged;");
        }
    }
}
