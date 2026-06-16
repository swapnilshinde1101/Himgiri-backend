using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixSpStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9192));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9235));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9844));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9900));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(225));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(239));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(62));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(275));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 60, DateTimeKind.Utc).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 50, 18, 59, DateTimeKind.Utc).AddTicks(9988));

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
                    ""Description"" VARCHAR,
                    ""DisplayOrder"" INT,
                    ""IsActive"" BOOLEAN,
                    ""CreatedAt"" TIMESTAMPTZ,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredGrades AS (
                        SELECT 
                            g.""Id"" as f_Id, g.""Name"" as f_Name, g.""ShortName"" as f_ShortName, 
                            g.""Description"" as f_Description, g.""DisplayOrder"" as f_DisplayOrder, 
                            g.""IsActive"" as f_IsActive, g.""CreatedAt"" as f_CreatedAt,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM ""Grades"" g
                        WHERE g.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR g.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR g.""ShortName"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT 
                        f_Id::UUID, f_Name::VARCHAR, f_ShortName::VARCHAR, 
                        f_Description::VARCHAR, f_DisplayOrder::INT, f_IsActive::BOOLEAN, 
                        f_CreatedAt::TIMESTAMPTZ, f_TotalCount::INT
                    FROM FilteredGrades
                    ORDER BY f_DisplayOrder ASC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");

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
                    ""Description"" VARCHAR,
                    ""IsActive"" BOOLEAN,
                    ""DisplayOrder"" INT,
                    ""HsnCode"" VARCHAR,
                    ""GstPercent"" NUMERIC,
                    ""CgstPercent"" NUMERIC,
                    ""SgstPercent"" NUMERIC,
                    ""IsTaxable"" BOOLEAN,
                    ""CreatedAt"" TIMESTAMPTZ,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredCats AS (
                        SELECT 
                            c.""Id"" as f_Id, c.""Name"" as f_Name, c.""Description"" as f_Description, 
                            c.""IsActive"" as f_IsActive, c.""DisplayOrder"" as f_DisplayOrder, 
                            c.""HsnCode"" as f_HsnCode, c.""GstPercent"" as f_GstPercent, 
                            c.""CgstPercent"" as f_CgstPercent, c.""SgstPercent"" as f_SgstPercent, 
                            c.""IsTaxable"" as f_IsTaxable, c.""CreatedAt"" as f_CreatedAt,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM ""ItemCategories"" c
                        WHERE c.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR c.""HsnCode"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT 
                        f_Id::UUID, f_Name::VARCHAR, f_Description::VARCHAR, 
                        f_IsActive::BOOLEAN, f_DisplayOrder::INT, f_HsnCode::VARCHAR, 
                        f_GstPercent::NUMERIC, f_CgstPercent::NUMERIC, f_SgstPercent::NUMERIC, 
                        f_IsTaxable::BOOLEAN, f_CreatedAt::TIMESTAMPTZ, f_TotalCount::INT
                    FROM FilteredCats
                    ORDER BY f_DisplayOrder ASC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3382));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4146));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 6, 16, 18, 41, 49, 67, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetGradesPaged(VARCHAR, INT, INT);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS usp_GetCategoriesPaged(VARCHAR, INT, INT);");
        }
    }
}
