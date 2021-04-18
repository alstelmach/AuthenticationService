using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AsCore.Application.Abstractions.Repositories;
using User.Application.Dto;

namespace User.Application.Repositories
{
    public interface IRoleDtoRepository : IReadModelRepository<RoleDto>
    {
        Task CreatePermissionAssignmentAsync(Guid permissionId, Guid roleId);
        Task<RoleDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<RoleDto>> GetUserRolesAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
