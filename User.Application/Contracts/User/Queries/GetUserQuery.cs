using System;
using System.Security.Claims;
using AsCore.Application.Abstractions.Messaging.Queries;
using User.Application.Dto;

namespace User.Application.Contracts.User.Queries
{
    public sealed class GetUserQuery : IQuery<UserDto>
    {
        public Guid Id { get; init; }
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
