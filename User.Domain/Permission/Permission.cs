using System;
using Core.Domain.Abstractions.BuildingBlocks;
using User.Domain.Permission.Events;

namespace User.Domain.Permission
{
    public sealed class Permission : AggregateRoot
    {
        internal Permission(Guid id,
            string description)
            : base(id)
        {
            Description = description;
            Enqueue(new PermissionCreatedDomainEvent(Id, Description));
        }

        public string Description { get; private set; }

        private void Apply(PermissionCreatedDomainEvent @event) =>
            (Id, Description) = (@event.EntityId, @event.Description);
    }
}
