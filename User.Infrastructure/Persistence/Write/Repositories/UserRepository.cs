using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AsCore.Domain.Abstractions.BuildingBlocks;
using AsCore.Infrastructure.Persistence.Marten;
using User.Domain.User.Repositories;
using User.Domain.User.Enumerations;
using User.Domain.User.Events;

namespace User.Infrastructure.Persistence.Write.Repositories
{
    public sealed class UserRepository : Repository<Domain.User.User>,
        IUserRepository
    {
        public UserRepository(IEventStore eventStore)
            : base(eventStore)
        {
        }

        public new async Task<Domain.User.User> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await EventStore.FindAsync<Domain.User.User>(id, cancellationToken);

            var returnValue = user is null || user.Status == UserStatus.Deleted
                ? null
                : user;

            return returnValue;
        }

        public async Task<bool> CheckIsLoginFreeAsync(string login, CancellationToken cancellationToken = default) =>
            (await EventStore
                .GetDomainEventsAsync<UserCreatedDomainEvent>(cancellationToken))
                .All(@event => @event.Login != login);

        public async Task<bool> CheckIsMailAddressFreeAsync(string mailAddress, CancellationToken cancellationToken = default) =>
            (await EventStore
                .GetDomainEventsAsync<UserCreatedDomainEvent>(cancellationToken))
                .All(@event => @event.MailAddress != mailAddress);
    }
}
