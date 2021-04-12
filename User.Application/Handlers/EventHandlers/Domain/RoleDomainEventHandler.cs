using System.Threading;
using System.Threading.Tasks;
using Core.Application.Abstractions.Messaging.Events;
using User.Application.Dto.Role;
using User.Domain.Role.Events;

namespace User.Application.Handlers.EventHandlers.Domain
{
    public sealed class RoleDomainEventHandler : IDomainEventHandler<RoleCreatedDomainEvent>,
        IDomainEventHandler<PermissionAssignedToRoleDomainEvent>
    {
        private readonly IRoleDtoRepository _roleDtoRepository;

        public RoleDomainEventHandler(IRoleDtoRepository roleDtoRepository)
        {
            _roleDtoRepository = roleDtoRepository;
        }
        
        public async Task Handle(RoleCreatedDomainEvent @event, CancellationToken cancellationToken)
        {
            var roleDto = new RoleDto(@event.EntityId, @event.Name);
            await _roleDtoRepository.CreateAsync(roleDto);
        }

        public async Task Handle(PermissionAssignedToRoleDomainEvent @event, CancellationToken cancellationToken) =>
            await _roleDtoRepository.CreatePermissionAssignmentAsync(@event.PermissionId, @event.EntityId, cancellationToken);
    }
}
