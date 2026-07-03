using Himgiri.Core.DTOs;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Services;

public interface IGradeService
{
    Task<JsonModel<List<GradeDto>>> GetAllAsync(CancellationToken ct = default);
    Task<JsonModel<List<GradeDto>>> GetPagedAsync(BaseRequest request, CancellationToken ct = default);
    Task<JsonModel<GradeDto>> CreateAsync(GradeDto request, CancellationToken ct = default);
    Task<JsonModel<GradeDto>> UpdateAsync(Guid id, GradeDto request, CancellationToken ct = default);
    Task<JsonModel<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<JsonModel<List<string>>> GetSuggestionsAsync(string term, CancellationToken ct = default);
}

public interface ICategoryService
{
    Task<JsonModel<List<CategoryDto>>> GetAllAsync(CancellationToken ct = default);
    Task<JsonModel<List<CategoryDto>>> GetPagedAsync(BaseRequest request, CancellationToken ct = default);
    Task<JsonModel<CategoryDto>> CreateAsync(CategoryDto request, CancellationToken ct = default);
    Task<JsonModel<CategoryDto>> UpdateAsync(Guid id, CategoryDto request, CancellationToken ct = default);
    Task<JsonModel<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<JsonModel<List<string>>> GetSuggestionsAsync(string term, CancellationToken ct = default);
}

public interface IGstRateService
{
    Task<JsonModel<List<GstRateDto>>> GetAllAsync(CancellationToken ct = default);
    Task<JsonModel<List<GstRateDto>>> GetPagedAsync(BaseRequest request, CancellationToken ct = default);
    Task<JsonModel<GstRateDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<JsonModel<GstRateDto>> CreateAsync(GstRateDto request, CancellationToken ct = default);
    Task<JsonModel<GstRateDto>> UpdateAsync(Guid id, GstRateDto request, CancellationToken ct = default);
    Task<JsonModel<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
}

public interface IStateService
{
    Task<JsonModel<List<StateDto>>> GetAllActiveAsync(CancellationToken ct = default);
    Task<JsonModel<List<StateDto>>> GetAllAsync(CancellationToken ct = default);
}
