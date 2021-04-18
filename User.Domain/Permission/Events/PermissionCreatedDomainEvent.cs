using System;
using AsCore.Domain.Abstractions.BuildingBlocks;

namespace User.Domain.Permission.Events
{
    public sealed class PermissionCreatedDomainEvent : DomainEvent
    {
        public PermissionCreatedDomainEvent(Guid entityId,
            string description)
                : base(entityId) =>
                    Description = description;
        
        public string Description { get; }
    }
}
