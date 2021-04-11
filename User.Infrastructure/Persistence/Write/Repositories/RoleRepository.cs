using Core.Domain.Abstractions.BuildingBlocks;
using Core.Infrastructure.Persistence.Marten;
using User.Domain.Roles;
using User.Domain.Roles.Repositories;

namespace User.Infrastructure.Persistence.Write.Repositories
{
    public sealed class RoleRepository : Repository<Role>,
        IRoleRepository
    {
        public RoleRepository(IEventStore eventStore)
            : base(eventStore)
        {
        }
    }
}
