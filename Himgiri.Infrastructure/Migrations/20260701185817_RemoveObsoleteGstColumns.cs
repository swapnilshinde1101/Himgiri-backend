using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveObsoleteGstColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CgstPercent",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "GstPercent",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "HsnCode",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "IsTaxable",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "SgstPercent",
                table: "ItemCategories");

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7290));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7975));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7979));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8254));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8263));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 58, 16, 944, DateTimeKind.Utc).AddTicks(8117));

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
                    ""DefaultGstRateId"" UUID,
                    ""CreatedAt"" TIMESTAMPTZ,
                    ""TotalCount"" INT
                ) AS $$
                BEGIN
                    RETURN QUERY
                    WITH FilteredCats AS (
                        SELECT 
                            c.""Id"" as f_Id, c.""Name"" as f_Name, c.""Description"" as f_Description, 
                            c.""IsActive"" as f_IsActive, c.""DisplayOrder"" as f_DisplayOrder, 
                            COALESCE(g.""HsnCode"", '') as f_HsnCode, 
                            COALESCE(g.""Rate"", 0.0) as f_GstPercent, 
                            COALESCE(g.""Cgst"", 0.0) as f_CgstPercent, 
                            COALESCE(g.""Sgst"", 0.0) as f_SgstPercent, 
                            (g.""Id"" IS NOT NULL AND g.""Rate"" > 0) as f_IsTaxable,
                            c.""DefaultGstRateId"" as f_DefaultGstRateId,
                            c.""CreatedAt"" as f_CreatedAt,
                            COUNT(*) OVER()::INT as f_TotalCount
                        FROM ""ItemCategories"" c
                        LEFT JOIN ""GstRates"" g ON c.""DefaultGstRateId"" = g.""Id"" AND g.""IsDeleted"" = FALSE
                        WHERE c.""IsDeleted"" = FALSE
                          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
                               OR c.""Name"" ILIKE '%' || p_SearchTerm || '%' 
                               OR g.""HsnCode"" ILIKE '%' || p_SearchTerm || '%')
                    )
                    SELECT 
                        f_Id::UUID, f_Name::VARCHAR, f_Description::VARCHAR, 
                        f_IsActive::BOOLEAN, f_DisplayOrder::INT, f_HsnCode::VARCHAR, 
                        f_GstPercent::NUMERIC, f_CgstPercent::NUMERIC, f_SgstPercent::NUMERIC, 
                        f_IsTaxable::BOOLEAN, f_DefaultGstRateId::UUID, f_CreatedAt::TIMESTAMPTZ, f_TotalCount::INT
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
            migrationBuilder.AddColumn<decimal>(
                name: "CgstPercent",
                table: "ItemCategories",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GstPercent",
                table: "ItemCategories",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "HsnCode",
                table: "ItemCategories",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxable",
                table: "ItemCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "SgstPercent",
                table: "ItemCategories",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(3454));

            migrationBuilder.UpdateData(
                table: "AdminUsers",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0001-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(3459));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0005-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "GstRates",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0009-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000001"),
                columns: new[] { "CgstPercent", "CreatedAt", "GstPercent", "HsnCode", "IsTaxable", "SgstPercent" },
                values: new object[] { 0m, new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4627), 0m, "4901", false, 0m });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000002"),
                columns: new[] { "CgstPercent", "CreatedAt", "GstPercent", "HsnCode", "IsTaxable", "SgstPercent" },
                values: new object[] { 6m, new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4636), 12m, "4820", true, 6m });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000003"),
                columns: new[] { "CgstPercent", "CreatedAt", "GstPercent", "HsnCode", "IsTaxable", "SgstPercent" },
                values: new object[] { 6m, new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4639), 12m, "4820", true, 6m });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000004"),
                columns: new[] { "CgstPercent", "CreatedAt", "GstPercent", "HsnCode", "IsTaxable", "SgstPercent" },
                values: new object[] { 9m, new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4642), 18m, "4202", true, 9m });

            migrationBuilder.UpdateData(
                table: "ItemCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0006-000000000005"),
                columns: new[] { "CgstPercent", "CreatedAt", "GstPercent", "HsnCode", "IsTaxable", "SgstPercent" },
                values: new object[] { 9m, new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4645), 18m, "9965", true, 9m });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000004"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000005"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000011"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000012"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000013"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4924));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0004-000000000033"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000002"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "SchoolKits",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0007-000000000003"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(5279));

            migrationBuilder.UpdateData(
                table: "VendorSettings",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0003-000000000001"),
                column: "CreatedAt",
                value: new DateTime(2026, 7, 1, 18, 45, 40, 233, DateTimeKind.Utc).AddTicks(4746));

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
    }
}
