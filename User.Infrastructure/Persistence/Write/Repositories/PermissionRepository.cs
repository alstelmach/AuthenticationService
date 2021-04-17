using AsCore.Domain.Abstractions.BuildingBlocks;
using AsCore.Infrastructure.Persistence.Marten;
using User.Domain.Permission;
using User.Domain.Permission.Repositories;

namespace User.Infrastructure.Persistence.Write.Repositories
{
    public sealed class PermissionRepository : Repository<Permission>,
        IPermissionRepository
    {
        public PermissionRepository(IEventStore eventStore)
            : base(eventStore)
        {
        }
    }
}
