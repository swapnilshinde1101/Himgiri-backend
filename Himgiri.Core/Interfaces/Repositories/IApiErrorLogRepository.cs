using Himgiri.Core.Entities;

namespace Himgiri.Core.Interfaces.Repositories;

public interface IApiErrorLogRepository
{
    Task AddAsync(ApiErrorLog log, CancellationToken ct = default);
}
