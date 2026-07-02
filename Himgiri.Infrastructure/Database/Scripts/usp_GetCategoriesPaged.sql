CREATE OR REPLACE FUNCTION usp_GetCategoriesPaged(
    p_SearchTerm VARCHAR,
    p_PageNumber INT,
    p_PageSize INT
)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR,
    "Description" TEXT,
    "IsActive" BOOLEAN,
    "DisplayOrder" INT,
    "HsnCode" VARCHAR,
    "GstPercent" NUMERIC,
    "CgstPercent" NUMERIC,
    "SgstPercent" NUMERIC,
    "IsTaxable" BOOLEAN,
    "CreatedAt" TIMESTAMPTZ,
    "TotalCount" INT
) AS $$
BEGIN
    RETURN QUERY
    WITH FilteredCats AS (
        SELECT 
            c."Id" as f_Id, 
            c."Name" as f_Name, 
            c."Description" as f_Description,
            c."IsActive" as f_IsActive,
            c."DisplayOrder" as f_DisplayOrder,
            c."HsnCode" as f_HsnCode, 
            c."GstPercent" as f_GstPercent, 
            c."CgstPercent" as f_CgstPercent, 
            c."SgstPercent" as f_SgstPercent, 
            c."IsTaxable" as f_IsTaxable,
            c."CreatedAt" as f_CreatedAt,
            COUNT(*) OVER()::INT as f_TotalCount
        FROM "ItemCategories" c
        WHERE c."IsDeleted" = FALSE
          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
               OR c."Name" ILIKE '%' || p_SearchTerm || '%' 
               OR c."HsnCode" ILIKE '%' || p_SearchTerm || '%')
    )
    SELECT 
        f_Id::UUID, 
        f_Name::VARCHAR, 
        f_Description::TEXT,
        f_IsActive::BOOLEAN, 
        f_DisplayOrder::INT,
        f_HsnCode::VARCHAR, 
        f_GstPercent::NUMERIC, 
        f_CgstPercent::NUMERIC, 
        f_SgstPercent::NUMERIC, 
        f_IsTaxable::BOOLEAN,
        f_CreatedAt::TIMESTAMPTZ,
        f_TotalCount::INT
    FROM FilteredCats
    ORDER BY f_DisplayOrder ASC, f_Name ASC
    OFFSET (p_PageNumber - 1) * p_PageSize
    LIMIT p_PageSize;
END;
$$ LANGUAGE plpgsql;
