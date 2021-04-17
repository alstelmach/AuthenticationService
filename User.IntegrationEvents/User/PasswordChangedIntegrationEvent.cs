using System;
using AsCore.Application.Abstractions.Messaging.Events;

namespace User.IntegrationEvents.User
{
    public sealed class PasswordChangedIntegrationEvent : IntegrationEvent
    {
        public PasswordChangedIntegrationEvent(Guid entityId)
            : base(entityId,
                nameof(PasswordChangedIntegrationEvent))
        {
        }
    }
}
