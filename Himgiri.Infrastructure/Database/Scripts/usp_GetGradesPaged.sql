CREATE OR REPLACE FUNCTION usp_GetGradesPaged(
    p_SearchTerm VARCHAR,
    p_PageNumber INT,
    p_PageSize INT
)
RETURNS TABLE (
    "Id" UUID,
    "Name" VARCHAR,
    "ShortName" VARCHAR,
    "Description" TEXT,
    "DisplayOrder" INT,
    "IsActive" BOOLEAN,
    "CreatedAt" TIMESTAMPTZ,
    "TotalCount" INT
) AS $$
BEGIN
    RETURN QUERY
    WITH FilteredGrades AS (
        SELECT 
            g."Id" as f_Id, 
            g."Name" as f_Name, 
            g."ShortName" as f_ShortName, 
            g."Description" as f_Description,
            g."DisplayOrder" as f_DisplayOrder, 
            g."IsActive" as f_IsActive,
            g."CreatedAt" as f_CreatedAt,
            COUNT(*) OVER()::INT as f_TotalCount
        FROM "Grades" g
        WHERE g."IsDeleted" = FALSE
          AND (p_SearchTerm IS NULL OR p_SearchTerm = '' 
               OR g."Name" ILIKE '%' || p_SearchTerm || '%' 
               OR g."ShortName" ILIKE '%' || p_SearchTerm || '%')
    )
    SELECT 
        f_Id::UUID, 
        f_Name::VARCHAR, 
        f_ShortName::VARCHAR, 
        f_Description::TEXT,
        f_DisplayOrder::INT, 
        f_IsActive::BOOLEAN, 
        f_CreatedAt::TIMESTAMPTZ,
        f_TotalCount::INT
    FROM FilteredGrades
    ORDER BY f_DisplayOrder ASC
    OFFSET (p_PageNumber - 1) * p_PageSize
    LIMIT p_PageSize;
END;
$$ LANGUAGE plpgsql;
