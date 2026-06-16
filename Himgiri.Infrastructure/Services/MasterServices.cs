using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Core.Models;
using Mapster;

namespace Himgiri.Infrastructure.Services;

public class GradeService : IGradeService
{
    private readonly IGradeRepository _repo;
    private readonly IUnitOfWork _uow;

    public GradeService(IGradeRepository repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<JsonModel<List<GradeDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var grades = await _repo.GetAllAsync(ct);
        return JsonModel<List<GradeDto>>.Success(MapToDtos(grades));
    }

    public async Task<JsonModel<List<GradeDto>>> GetPagedAsync(BaseRequest request, CancellationToken ct = default)
    {
        var (items, total) = await _repo.GetPagedAsync(request, ct);
        var dtos = MapToDtos(items);
        return new JsonModel<List<GradeDto>>(dtos, "Success", 200, "", new Meta(total, request.PageNumber, request.PageSize));
    }

    public async Task<JsonModel<GradeDto>> CreateAsync(GradeDto request, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return JsonModel<GradeDto>.Error("Grade Name is required.", 400);
        }

        var trimmedName = request.Name.Trim();
        if (trimmedName.Length < 3 || trimmedName.Length > 15)
        {
            return JsonModel<GradeDto>.Error("Grade Name must be between 3 and 15 characters.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.ShortName))
        {
            return JsonModel<GradeDto>.Error("Short Name is required.", 400);
        }

        var allGrades = await _repo.GetAllAsync(ct);
        if (allGrades.Any(g => g.Name.Equals(trimmedName, StringComparison.OrdinalIgnoreCase)))
        {
            return JsonModel<GradeDto>.Error("Grade Name already exists.", 400);
        }
        if (allGrades.Any(g => g.ShortName.Equals(request.ShortName.Trim(), StringComparison.OrdinalIgnoreCase)))
        {
            return JsonModel<GradeDto>.Error("Grade Short Name already exists.", 400);
        }

        // ── Smart Re-ordering Logic ──
        if (allGrades.Any(g => g.DisplayOrder == request.DisplayOrder))
        {
            var gradesToShift = allGrades.Where(g => g.DisplayOrder >= request.DisplayOrder);
            foreach (var g in gradesToShift)
            {
                g.DisplayOrder += 1;
                _repo.Update(g);
            }
        }

        var grade = new Grade
        {
            Name = trimmedName,
            ShortName = request.ShortName.Trim(),
            Description = request.Description ?? string.Empty,
            IsActive = request.IsActive,
            DisplayOrder = request.DisplayOrder
        };

        _repo.Add(grade);
        await _uow.CommitAsync(ct);
        return JsonModel<GradeDto>.Success(MapToDto(grade), "Grade created and order adjusted.");
    }

    public async Task<JsonModel<GradeDto>> UpdateAsync(Guid id, GradeDto request, CancellationToken ct = default)
    {
        var grade = await _repo.GetByIdAsync(id, ct);
        if (grade == null) return JsonModel<GradeDto>.Error("Grade not found", 404);

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return JsonModel<GradeDto>.Error("Grade Name is required.", 400);
        }

        var trimmedName = request.Name.Trim();
        if (trimmedName.Length < 3 || trimmedName.Length > 15)
        {
            return JsonModel<GradeDto>.Error("Grade Name must be between 3 and 15 characters.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.ShortName))
        {
            return JsonModel<GradeDto>.Error("Short Name is required.", 400);
        }

        var allGrades = await _repo.GetAllAsync(ct);
        if (allGrades.Any(g => g.Name.Equals(trimmedName, StringComparison.OrdinalIgnoreCase) && g.Id != id))
        {
            return JsonModel<GradeDto>.Error("Grade Name already exists.", 400);
        }
        if (allGrades.Any(g => g.ShortName.Equals(request.ShortName.Trim(), StringComparison.OrdinalIgnoreCase) && g.Id != id))
        {
            return JsonModel<GradeDto>.Error("Grade Short Name already exists.", 400);
        }

        // If DisplayOrder is changing, handle the shift
        if (grade.DisplayOrder != request.DisplayOrder)
        {
            if (request.DisplayOrder < grade.DisplayOrder)
            {
                // Moving UP: Shift items in between DOWN
                var shiftDown = allGrades.Where(g => g.DisplayOrder >= request.DisplayOrder && g.DisplayOrder < grade.DisplayOrder && g.Id != id);
                foreach (var g in shiftDown) { g.DisplayOrder += 1; _repo.Update(g); }
            }
            else
            {
                // Moving DOWN: Shift items in between UP
                var shiftUp = allGrades.Where(g => g.DisplayOrder <= request.DisplayOrder && g.DisplayOrder > grade.DisplayOrder && g.Id != id);
                foreach (var g in shiftUp) { g.DisplayOrder -= 1; _repo.Update(g); }
            }
        }

        grade.Name = trimmedName;
        grade.ShortName = request.ShortName.Trim();
        grade.Description = request.Description ?? string.Empty;
        grade.IsActive = request.IsActive;
        grade.DisplayOrder = request.DisplayOrder;

        _repo.Update(grade);
        await _uow.CommitAsync(ct);
        return JsonModel<GradeDto>.Success(MapToDto(grade), "Grade updated and order adjusted.");
    }

    private List<GradeDto> MapToDtos(IEnumerable<Grade> grades)
    {
        return grades.Select(MapToDto).ToList();
    }

    private GradeDto MapToDto(Grade g)
    {
        return new GradeDto(
            g.Id,
            g.Name,
            g.ShortName,
            g.Description,
            g.IsActive,
            g.DisplayOrder
        );
    }

    public async Task<JsonModel<bool>> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var grade = await _repo.GetByIdAsync(id, ct);
        if (grade == null) return JsonModel<bool>.Error("Grade not found", 404);

        if (await _repo.HasLinkedItemsAsync(id, ct))
        {
            return JsonModel<bool>.Error("Cannot delete this Grade because it is assigned to one or more active catalog items. Reassign those items first.", 400);
        }

        _repo.Delete(grade);
        var success = await _uow.CommitAsync(ct);
        return JsonModel<bool>.Success(success, "Grade deleted");
    }

    public async Task<JsonModel<List<string>>> GetSuggestionsAsync(string term, CancellationToken ct = default)
    {
        var suggestions = await _repo.GetSuggestionsAsync(term, ct);
        return JsonModel<List<string>>.Success(suggestions);
    }
}

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repo;
    private readonly IUnitOfWork _uow;

    public CategoryService(ICategoryRepository repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<JsonModel<List<CategoryDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var categories = await _repo.GetAllAsync(ct);
        return JsonModel<List<CategoryDto>>.Success(MapToDtos(categories));
    }

    public async Task<JsonModel<List<CategoryDto>>> GetPagedAsync(BaseRequest request, CancellationToken ct = default)
    {
        var (items, total) = await _repo.GetPagedAsync(request, ct);
        var dtos = MapToDtos(items);
        return new JsonModel<List<CategoryDto>>(dtos, "Success", 200, "", new Meta(total, request.PageNumber, request.PageSize));
    }

    public async Task<JsonModel<CategoryDto>> CreateAsync(CategoryDto request, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return JsonModel<CategoryDto>.Error("Category Name is required.", 400);
        }

        var trimmedName = request.Name.Trim();
        if (trimmedName.Length < 3 || trimmedName.Length > 15)
        {
            return JsonModel<CategoryDto>.Error("Category Name must be between 3 and 15 characters.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.HsnCode))
        {
            return JsonModel<CategoryDto>.Error("HSN Code is required.", 400);
        }

        var allCats = await _repo.GetAllAsync(ct);
        if (allCats.Any(c => c.Name.Equals(trimmedName, StringComparison.OrdinalIgnoreCase)))
        {
            return JsonModel<CategoryDto>.Error("Category Name already exists.", 400);
        }

        if (request.IsTaxable && !new decimal[] { 0m, 5m, 12m, 18m, 28m }.Contains(request.GstPercent))
        {
            return JsonModel<CategoryDto>.Error("GST rate must be a standard rate (0%, 5%, 12%, 18%, or 28%).");
        }

        // ── Smart Re-ordering Logic ──
        if (allCats.Any(c => c.DisplayOrder == request.DisplayOrder))
        {
            var catsToShift = allCats.Where(c => c.DisplayOrder >= request.DisplayOrder);
            foreach (var c in catsToShift)
            {
                c.DisplayOrder += 1;
                _repo.Update(c);
            }
        }

        var category = new ItemCategory
        {
            Name = trimmedName,
            Description = request.Description ?? string.Empty,
            DisplayOrder = request.DisplayOrder,
            HsnCode = request.HsnCode.Trim(),
            GstPercent = request.GstPercent,
            IsTaxable = request.IsTaxable,
            IsActive = request.IsActive
        };

        CalculateGst(category);

        _repo.Add(category);
        await _uow.CommitAsync(ct);
        return JsonModel<CategoryDto>.Success(MapToDto(category), "Category created and order adjusted.");
    }

    public async Task<JsonModel<CategoryDto>> UpdateAsync(Guid id, CategoryDto request, CancellationToken ct = default)
    {
        var category = await _repo.GetByIdAsync(id, ct);
        if (category == null) return JsonModel<CategoryDto>.Error("Category not found", 404);

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return JsonModel<CategoryDto>.Error("Category Name is required.", 400);
        }

        var trimmedName = request.Name.Trim();
        if (trimmedName.Length < 3 || trimmedName.Length > 15)
        {
            return JsonModel<CategoryDto>.Error("Category Name must be between 3 and 15 characters.", 400);
        }

        if (string.IsNullOrWhiteSpace(request.HsnCode))
        {
            return JsonModel<CategoryDto>.Error("HSN Code is required.", 400);
        }

        var allCats = await _repo.GetAllAsync(ct);
        if (allCats.Any(c => c.Name.Equals(trimmedName, StringComparison.OrdinalIgnoreCase) && c.Id != id))
        {
            return JsonModel<CategoryDto>.Error("Category Name already exists.", 400);
        }

        if (request.IsTaxable && !new decimal[] { 0m, 5m, 12m, 18m, 28m }.Contains(request.GstPercent))
        {
            return JsonModel<CategoryDto>.Error("GST rate must be a standard rate (0%, 5%, 12%, 18%, or 28%).");
        }

        // If DisplayOrder is changing, handle the shift
        if (category.DisplayOrder != request.DisplayOrder)
        {
            if (request.DisplayOrder < category.DisplayOrder)
            {
                // Moving UP: Shift items in between DOWN
                var shiftDown = allCats.Where(c => c.DisplayOrder >= request.DisplayOrder && c.DisplayOrder < category.DisplayOrder && c.Id != id);
                foreach (var c in shiftDown) { c.DisplayOrder += 1; _repo.Update(c); }
            }
            else
            {
                // Moving DOWN: Shift items in between UP
                var shiftUp = allCats.Where(c => c.DisplayOrder <= request.DisplayOrder && c.DisplayOrder > category.DisplayOrder && c.Id != id);
                foreach (var c in shiftUp) { c.DisplayOrder -= 1; _repo.Update(c); }
            }
        }

        category.Name = trimmedName;
        category.Description = request.Description ?? string.Empty;
        category.DisplayOrder = request.DisplayOrder;
        category.HsnCode = request.HsnCode.Trim();
        category.GstPercent = request.GstPercent;
        category.IsTaxable = request.IsTaxable;
        category.IsActive = request.IsActive;

        CalculateGst(category);

        _repo.Update(category);
        await _uow.CommitAsync(ct);
        return JsonModel<CategoryDto>.Success(MapToDto(category), "Category updated and order adjusted.");
    }

    private void CalculateGst(ItemCategory cat)
    {
        if (!cat.IsTaxable || cat.GstPercent == 0)
        {
            cat.GstPercent = 0;
            cat.CgstPercent = 0;
            cat.SgstPercent = 0;
            cat.IsTaxable = false;
        }
        else
        {
            cat.CgstPercent = cat.GstPercent / 2;
            cat.SgstPercent = cat.GstPercent / 2;
        }
    }

    private List<CategoryDto> MapToDtos(IEnumerable<ItemCategory> categories)
    {
        return categories.Select(MapToDto).ToList();
    }

    private CategoryDto MapToDto(ItemCategory c)
    {
        return new CategoryDto(
            c.Id,
            c.Name,
            c.Description,
            c.DisplayOrder,
            c.HsnCode,
            c.GstPercent,
            c.CgstPercent,
            c.SgstPercent,
            c.IsTaxable,
            c.IsActive
        );
    }

    public async Task<JsonModel<bool>> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var category = await _repo.GetByIdAsync(id, ct);
        if (category == null) return JsonModel<bool>.Error("Category not found", 404);

        if (await _repo.HasLinkedItemsAsync(id, ct))
        {
            return JsonModel<bool>.Error("Cannot delete this Category because it is assigned to one or more active catalog items. Reassign those items first.", 400);
        }

        _repo.Delete(category);
        var success = await _uow.CommitAsync(ct);
        return JsonModel<bool>.Success(success, "Category deleted");
    }

    public async Task<JsonModel<List<string>>> GetSuggestionsAsync(string term, CancellationToken ct = default)
    {
        var suggestions = await _repo.GetSuggestionsAsync(term, ct);
        return JsonModel<List<string>>.Success(suggestions);
    }
}
