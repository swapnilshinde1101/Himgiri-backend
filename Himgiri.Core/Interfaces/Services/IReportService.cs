using System;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.DTOs;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Services;

public interface IReportService
{
    Task<JsonModel<AccountReportSummaryDto>> GetAccountReportSummaryAsync(
        DateTime? startDate = null, 
        DateTime? endDate = null, 
        CancellationToken ct = default);

    Task<JsonModel<InventoryValuationReportDto>> GetInventoryValuationReportAsync(
        CancellationToken ct = default);

    Task<JsonModel<StaffActivityReportDto>> GetStaffActivityReportAsync(
        int limit = 50, 
        CancellationToken ct = default);
}
