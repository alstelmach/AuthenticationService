using System.Collections.Generic;
using System.Security.Claims;
using AsCore.Application.Abstractions.Messaging.Queries;
using User.Application.Dto;

namespace User.Application.Contracts.User.Queries
{
    public sealed class GetUsersQuery : IQuery<IEnumerable<UserDto>>
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
