using Core.Domain.Abstractions.BuildingBlocks;
using Core.Infrastructure.Persistence.Marten;
using User.Domain.Role;
using User.Domain.Role.Repositories;

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
