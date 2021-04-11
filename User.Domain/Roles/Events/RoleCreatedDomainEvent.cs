using System;
using Core.Domain.Abstractions.BuildingBlocks;

namespace User.Domain.Roles.Events
{
    public sealed class RoleCreatedDomainEvent : DomainEvent
    {
        public RoleCreatedDomainEvent(Guid entityId,
            string name)
                : base(entityId) =>
                    Name = name;
        
        public string Name { get; }
    }
}
