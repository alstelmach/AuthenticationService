using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Infrastructure.Persistence.BuildingBlocks;
using User.Application.Dto.Role;
using User.Infrastructure.Persistence.Read.Context;
using User.Infrastructure.Persistence.Read.Entities;

namespace User.Infrastructure.Persistence.Read.Repositories
{
    public sealed class RoleDtoRepository : ReadModelRepository<RoleDto>,
        IRoleDtoRepository
    {
        public RoleDtoRepository(UserReadModelContext dbContext)
            : base(dbContext)
        {
        }

        public async Task CreatePermissionAssignmentAsync(Guid permissionId,
            Guid roleId,
            CancellationToken cancellationToken)
        {
            var assignment = new RolePermissionAssignment(roleId, permissionId);

            await DbContext
                .Set<RolePermissionAssignment>()
                .AddAsync(assignment, cancellationToken);
        }
    }
}
