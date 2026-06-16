using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.DTOs;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Services;

public interface ISchoolKitService
{
    Task<JsonModel<SchoolKitDto>> CreateKitAsync(CreateSchoolKitRequest request, CancellationToken ct = default);
    Task<JsonModel<SchoolKitDto>> GetKitByIdAsync(Guid id, CancellationToken ct = default);
    Task<JsonModel<List<SchoolKitDto>>> GetKitsByGradeIdAsync(Guid gradeId, CancellationToken ct = default);
    Task<JsonModel<List<SchoolKitDto>>> GetPagedKitsAsync(BaseRequest request, CancellationToken ct = default);
    Task<JsonModel<SchoolKitDto>> UpdateKitAsync(Guid id, CreateSchoolKitRequest request, CancellationToken ct = default);
    Task<JsonModel<bool>> DeleteKitAsync(Guid id, CancellationToken ct = default);
}
