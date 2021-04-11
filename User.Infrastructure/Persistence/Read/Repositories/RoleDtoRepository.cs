using Core.Infrastructure.Persistence.BuildingBlocks;
using User.Application.Dto.Role;
using User.Infrastructure.Persistence.Read.Context;

namespace User.Infrastructure.Persistence.Read.Repositories
{
    public sealed class RoleDtoRepository : ReadModelRepository<RoleDto>,
        IRoleDtoRepository
    {
        public RoleDtoRepository(UserReadModelContext dbContext)
            : base(dbContext)
        {
        }
    }
}
