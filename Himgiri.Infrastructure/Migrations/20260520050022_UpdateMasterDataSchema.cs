using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMasterDataSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SpGetGradesPagedResults",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SpGetCategoriesPagedResults",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "SpGetCategoriesPagedResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxable",
                table: "SpGetCategoriesPagedResults",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ItemCategories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "ItemCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Grades",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2164));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2170));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2341), "Primary Grade 1" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2343), "Primary Grade 2" });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2348), "Primary Grade 3" });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                columns: new[] { "CreatedAt", "Description", "DisplayOrder", "IsTaxable" },
                values: new object[] { new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2369), "School Textbooks", 1, false });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                columns: new[] { "CreatedAt", "Description", "DisplayOrder" },
                values: new object[] { new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2373), "School Stationery", 2 });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                columns: new[] { "CreatedAt", "Description", "DisplayOrder" },
                values: new object[] { new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2374), "School Journals", 3 });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                columns: new[] { "CreatedAt", "Description", "DisplayOrder" },
                values: new object[] { new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2375), "School Bags", 4 });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                columns: new[] { "CreatedAt", "Description", "DisplayOrder" },
                values: new object[] { new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2376), "Delivery Charges", 5 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2436));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 5, 20, 5, 0, 21, 487, DateTimeKind.Utc).AddTicks(2413));

            // ── Update usp_GetGradesPaged ──
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
                    ""Description"" TEXT,
                    ""DisplayOrder"" INT,
                    ""IsActive"" BOOLEAN,
                    ""CreatedAt"" TIMESTAMPTZ,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredGrades AS (
                        SELECT 
                            g.""Id"", g.""Name"", g.""ShortName"", g.""Description"", g.""DisplayOrder"", g.""IsActive"", g.""CreatedAt"",
                            COUNT(*) OVER()::INT as ""TotalCount""
                        FROM ""Grades"" g
                        WHERE g.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR g.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR g.""ShortName"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT f.* FROM FilteredGrades f
                    ORDER BY f.""DisplayOrder"" ASC, f.""Name"" ASC
                    OFFSET (p_PageNumber - 1) * p_PageSize
                    LIMIT p_PageSize;
                END;
                $$ LANGUAGE plpgsql;
            ");

            // ── Update usp_GetCategoriesPaged ──
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
                    ""Description"" TEXT,
                    ""IsActive"" BOOLEAN,
                    ""DisplayOrder"" INT,
                    ""HsnCode"" VARCHAR,
                    ""GstPercent"" DECIMAL,
                    ""CgstPercent"" DECIMAL,
                    ""SgstPercent"" DECIMAL,
                    ""IsTaxable"" BOOLEAN,
                    ""CreatedAt"" TIMESTAMPTZ,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredCats AS (
                        SELECT 
                            c.""Id"", c.""Name"", c.""Description"", c.""IsActive"", c.""DisplayOrder"", 
                            c.""HsnCode"", c.""GstPercent"", c.""CgstPercent"", c.""SgstPercent"", c.""IsTaxable"", c.""CreatedAt"",
                            COUNT(*) OVER()::INT as ""TotalCount""
                        FROM ""ItemCategories"" c
                        WHERE c.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR c.""HsnCode"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT f.* FROM FilteredCats f
                    ORDER BY f.""DisplayOrder"" ASC, f.""Name"" ASC
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
                name: "Description",
                table: "SpGetGradesPagedResults");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SpGetCategoriesPagedResults");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "SpGetCategoriesPagedResults");

            migrationBuilder.DropColumn(
                name: "IsTaxable",
                table: "SpGetCategoriesPagedResults");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Grades");

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
                columns: new[] { "CreatedAt", "IsTaxable" },
                values: new object[] { new DateTime(2026, 5, 17, 12, 34, 12, 741, DateTimeKind.Utc).AddTicks(7653), true });

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
    }
}
