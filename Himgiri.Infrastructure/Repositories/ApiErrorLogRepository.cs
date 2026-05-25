using Himgiri.Core.Entities;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Infrastructure.Data;

namespace Himgiri.Infrastructure.Repositories;

public class ApiErrorLogRepository : IApiErrorLogRepository
{
    private readonly HimgiriDbContext _db;

    public ApiErrorLogRepository(HimgiriDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(ApiErrorLog log, CancellationToken ct = default)
    {
        await _db.Set<ApiErrorLog>().AddAsync(log, ct);
        await _db.SaveChangesAsync(ct);
    }
}
