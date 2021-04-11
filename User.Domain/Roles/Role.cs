using System;
using Core.Domain.Abstractions.BuildingBlocks;
using User.Domain.Roles.Events;

namespace User.Domain.Roles
{
    public sealed class Role : AggregateRoot
    {
        internal Role(Guid id,
            string name)
                : base(id)
        {
            Name = name;
            Enqueue(new RoleCreatedDomainEvent(Id, Name));
        }
        
        public string Name { get; private set; }

        private void Apply(RoleCreatedDomainEvent @event) =>
            (Id, Name) = (@event.EntityId, @event.Name);
    }
}
