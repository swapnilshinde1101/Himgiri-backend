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
    private readonly IGstRateRepository _gstRateRepo;
    private readonly IUnitOfWork _uow;

    public CategoryService(ICategoryRepository repo, IGstRateRepository gstRateRepo, IUnitOfWork uow)
    {
        _repo = repo;
        _gstRateRepo = gstRateRepo;
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

        if (!request.DefaultGstRateId.HasValue)
        {
            return JsonModel<CategoryDto>.Error("Default GST Rate is required.", 400);
        }

        var gstRate = await _gstRateRepo.GetByIdAsync(request.DefaultGstRateId.Value, ct);
        if (gstRate == null)
            return JsonModel<CategoryDto>.Error("GST Rate not found.", 404);
        if (!gstRate.IsActive)
            return JsonModel<CategoryDto>.Error("Selected Default GST Rate is currently inactive.", 400);

        var allCats = await _repo.GetAllAsync(ct);
        if (allCats.Any(c => c.Name.Equals(trimmedName, StringComparison.OrdinalIgnoreCase)))
        {
            return JsonModel<CategoryDto>.Error("Category Name already exists.", 400);
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
            IsActive = request.IsActive,
            DefaultGstRateId = request.DefaultGstRateId.Value
        };

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

        if (!request.DefaultGstRateId.HasValue)
        {
            return JsonModel<CategoryDto>.Error("Default GST Rate is required.", 400);
        }

        var gstRate = await _gstRateRepo.GetByIdAsync(request.DefaultGstRateId.Value, ct);
        if (gstRate == null)
            return JsonModel<CategoryDto>.Error("GST Rate not found.", 404);
        if (!gstRate.IsActive)
            return JsonModel<CategoryDto>.Error("Selected Default GST Rate is currently inactive.", 400);

        var allCats = await _repo.GetAllAsync(ct);
        if (allCats.Any(c => c.Name.Equals(trimmedName, StringComparison.OrdinalIgnoreCase) && c.Id != id))
        {
            return JsonModel<CategoryDto>.Error("Category Name already exists.", 400);
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
        category.IsActive = request.IsActive;
        category.DefaultGstRateId = request.DefaultGstRateId.Value;

        _repo.Update(category);
        await _uow.CommitAsync(ct);
        return JsonModel<CategoryDto>.Success(MapToDto(category), "Category updated and order adjusted.");
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
            c.DefaultGstRate?.HsnCode ?? string.Empty,
            c.DefaultGstRate?.Rate ?? 0m,
            c.DefaultGstRate?.Cgst ?? 0m,
            c.DefaultGstRate?.Sgst ?? 0m,
            c.DefaultGstRate != null && c.DefaultGstRate.Rate > 0,
            c.IsActive,
            c.DefaultGstRateId
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

public class GstRateService : IGstRateService
{
    private readonly IGstRateRepository _repo;
    private readonly IUnitOfWork _uow;

    public GstRateService(IGstRateRepository repo, IUnitOfWork uow)
    {
        _repo = repo;
        _uow = uow;
    }

    public async Task<JsonModel<List<GstRateDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var rates = await _repo.GetAllAsync(ct);
        return JsonModel<List<GstRateDto>>.Success(MapToDtos(rates));
    }

    public async Task<JsonModel<List<GstRateDto>>> GetPagedAsync(BaseRequest request, CancellationToken ct = default)
    {
        var (items, total) = await _repo.GetPagedAsync(request, ct);
        var dtos = MapToDtos(items);
        return new JsonModel<List<GstRateDto>>(dtos, "Success", 200, "", new Meta(total, request.PageNumber, request.PageSize));
    }

    public async Task<JsonModel<GstRateDto>> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var rate = await _repo.GetByIdAsync(id, ct);
        if (rate == null)
            return JsonModel<GstRateDto>.Error("GST Rate not found.", 404);
        return JsonModel<GstRateDto>.Success(MapToDto(rate));
    }

    public async Task<JsonModel<GstRateDto>> CreateAsync(GstRateDto request, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return JsonModel<GstRateDto>.Error("Tax Slab Name is required.", 400);

        if (string.IsNullOrWhiteSpace(request.HsnCode))
            return JsonModel<GstRateDto>.Error("HSN Code is required.", 400);

        if (request.Rate < 0 || request.Rate > 100)
            return JsonModel<GstRateDto>.Error("GST Rate must be between 0 and 100.", 400);

        if (request.Cgst + request.Sgst != request.Rate)
            return JsonModel<GstRateDto>.Error("CGST + SGST must sum up to the total GST Rate.", 400);

        if (request.Igst != request.Rate)
            return JsonModel<GstRateDto>.Error("IGST must equal the total GST Rate.", 400);

        var rate = new GstRate
        {
            Name = request.Name.Trim(),
            HsnCode = request.HsnCode.Trim(),
            Description = request.Description ?? string.Empty,
            Rate = request.Rate,
            Cgst = request.Cgst,
            Sgst = request.Sgst,
            Igst = request.Igst,
            Cess = request.Cess,
            EffectiveFrom = request.EffectiveFrom.ToUniversalTime(),
            EffectiveTo = request.EffectiveTo?.ToUniversalTime(),
            IsActive = request.IsActive
        };

        _repo.Add(rate);
        await _uow.CommitAsync(ct);

        return JsonModel<GstRateDto>.Success(MapToDto(rate), "GST Rate created successfully.");
    }

    public async Task<JsonModel<GstRateDto>> UpdateAsync(Guid id, GstRateDto request, CancellationToken ct = default)
    {
        var rate = await _repo.GetByIdAsync(id, ct);
        if (rate == null)
            return JsonModel<GstRateDto>.Error("GST Rate not found.", 404);

        if (string.IsNullOrWhiteSpace(request.Name))
            return JsonModel<GstRateDto>.Error("Tax Slab Name is required.", 400);

        if (string.IsNullOrWhiteSpace(request.HsnCode))
            return JsonModel<GstRateDto>.Error("HSN Code is required.", 400);

        if (request.Rate < 0 || request.Rate > 100)
            return JsonModel<GstRateDto>.Error("GST Rate must be between 0 and 100.", 400);

        if (request.Cgst + request.Sgst != request.Rate)
            return JsonModel<GstRateDto>.Error("CGST + SGST must sum up to the total GST Rate.", 400);

        if (request.Igst != request.Rate)
            return JsonModel<GstRateDto>.Error("IGST must equal the total GST Rate.", 400);

        rate.Name = request.Name.Trim();
        rate.HsnCode = request.HsnCode.Trim();
        rate.Description = request.Description ?? string.Empty;
        rate.Rate = request.Rate;
        rate.Cgst = request.Cgst;
        rate.Sgst = request.Sgst;
        rate.Igst = request.Igst;
        rate.Cess = request.Cess;
        rate.EffectiveFrom = request.EffectiveFrom.ToUniversalTime();
        rate.EffectiveTo = request.EffectiveTo?.ToUniversalTime();
        rate.IsActive = request.IsActive;

        _repo.Update(rate);
        await _uow.CommitAsync(ct);

        return JsonModel<GstRateDto>.Success(MapToDto(rate), "GST Rate updated successfully.");
    }

    public async Task<JsonModel<bool>> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var rate = await _repo.GetByIdAsync(id, ct);
        if (rate == null)
            return JsonModel<bool>.Error("GST Rate not found.", 404);

        if (await _repo.HasLinkedCategoriesOrItemsAsync(id, ct))
        {
            return JsonModel<bool>.Error("Cannot delete this GST Rate because it is in use by categories or items.", 400);
        }

        _repo.Delete(rate);
        var success = await _uow.CommitAsync(ct);
        return JsonModel<bool>.Success(success, "GST Rate deleted successfully.");
    }

    private List<GstRateDto> MapToDtos(List<GstRate> rates)
    {
        return rates.Select(MapToDto).ToList();
    }

    private GstRateDto MapToDto(GstRate rate)
    {
        return new GstRateDto(
            rate.Id,
            rate.Name,
            rate.HsnCode,
            rate.Description ?? string.Empty,
            rate.Rate,
            rate.Cgst,
            rate.Sgst,
            rate.Igst,
            rate.Cess,
            rate.EffectiveFrom,
            rate.EffectiveTo,
            rate.IsActive
        );
    }
}

public class StateService : IStateService
{
    private readonly IStateRepository _repo;
    public StateService(IStateRepository repo) => _repo = repo;

    public async Task<JsonModel<List<StateDto>>> GetAllActiveAsync(CancellationToken ct = default)
    {
        var states = await _repo.GetAllActiveAsync(ct);
        return JsonModel<List<StateDto>>.Success(MapToDtos(states));
    }

    public async Task<JsonModel<List<StateDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var states = await _repo.GetAllAsync(ct);
        return JsonModel<List<StateDto>>.Success(MapToDtos(states));
    }

    private List<StateDto> MapToDtos(List<State> states)
    {
        return states.Select(MapToDto).ToList();
    }

    private StateDto MapToDto(State state)
    {
        return new StateDto(
            state.Id,
            state.StateCode,
            state.StateName,
            state.GstStateCode,
            state.IsUnionTerritory,
            state.IsActive
        );
    }
}
