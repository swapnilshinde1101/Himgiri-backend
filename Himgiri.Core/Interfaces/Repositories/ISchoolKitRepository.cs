using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.Entities;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Repositories;

public interface ISchoolKitRepository
{
    Task<SchoolKit?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<List<SchoolKit>> GetByGradeIdAsync(Guid gradeId, CancellationToken ct = default);
    Task<(List<SchoolKit> Items, int TotalCount)> GetPagedAsync(BaseRequest request, CancellationToken ct = default);
    void Add(SchoolKit kit);
    void Update(SchoolKit kit);
    void Delete(SchoolKit kit);
    Task<bool> ExistsByNameAsync(string name, Guid gradeId, Guid? excludeId = null, CancellationToken ct = default);
}
