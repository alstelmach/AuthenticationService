using System.Collections.Generic;
using System.Security.Claims;
using Core.Application.Abstractions.Messaging.Queries;
using User.Application.Dto.User;

namespace User.Application.Contracts.User.Queries
{
    public sealed class GetUsersQuery : IQuery<IEnumerable<UserDto>>
    {
        public ClaimsPrincipal ClaimsPrincipal { get; init; }
    }
}
