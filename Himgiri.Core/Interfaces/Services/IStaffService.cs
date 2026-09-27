using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Himgiri.Core.DTOs;
using Himgiri.Core.Models;

namespace Himgiri.Core.Interfaces.Services;

public interface IStaffService
{
    Task<JsonModel<List<StaffMemberDto>>> GetAllStaffAsync(CancellationToken ct = default);
    Task<JsonModel<StaffMemberDto>> GetStaffByIdAsync(Guid id, CancellationToken ct = default);
    Task<JsonModel<StaffMemberDto>> CreateStaffAsync(CreateStaffRequest request, CancellationToken ct = default);
    Task<JsonModel<StaffMemberDto>> UpdateStaffRoleAsync(Guid targetUserId, UpdateStaffRoleRequest request, Guid currentUserId, CancellationToken ct = default);
    Task<JsonModel<StaffMemberDto>> UpdateStaffStatusAsync(Guid targetUserId, UpdateStaffStatusRequest request, Guid currentUserId, CancellationToken ct = default);
    Task<JsonModel<bool>> ResetStaffPasswordAsync(Guid targetUserId, ResetStaffPasswordRequest request, CancellationToken ct = default);
    Task<JsonModel<bool>> UnlockStaffAccountAsync(Guid targetUserId, CancellationToken ct = default);
    Task<JsonModel<bool>> DeleteStaffAsync(Guid targetUserId, Guid currentUserId, CancellationToken ct = default);
}
